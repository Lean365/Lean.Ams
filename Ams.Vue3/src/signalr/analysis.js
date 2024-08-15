import { ElNotification, ElMessageBox } from 'element-plus'
import useSocketStore from '@/store/modules/socket'
import useUserStore from '@/store/modules/user'
import { webNotify } from '@/utils/index'
import gongaoIcon from '@/assets/icons/svg/gonggao.svg'

export default {
  onMessage(connection) {
    connection.on(MsgType.M001, (data) => {
      useSocketStore().setOnlineUsers(data)
    })

    // 接收后台手动推送消息
    connection.on('receiveNotice', (title, data) => {
      ElNotification({
        type: 'info',
        title: title,
        message: data,
        dangerouslyUseHTMLString: true,
        duration: 0
      })
      webNotify({ title: title, body: '你有一条新消息(You have one new message.)', icon: gongaoIcon })
    })
    // 接收系统通知/公告
    connection.on('moreNotice', (data) => {
      if (data.code == 200) {
        useSocketStore().setNoticeList(data.data)
      }
    })

    // 接收在线用户
    // connection.on('onlineUser', (data) => {
    //   useSocketStore().setOnlineUsers(data)
    // })

    // 接收强退通知
    connection.on('forceUser', (data) => {
      useSocketStore().setGlobalError({ code: 0, msg: `你的账号已被强退(Your account has been forced quit),原因(for a reason):${data.reason || '无(None)'} ` })
      useUserStore()
        .logOut()
        .then(() => {
          location.href = import.meta.env.VITE_APP_ROUTER_PREFIX + 'error'
        })
    })
    // 接收聊天数据
    connection.on('receiveChat', (data) => {
      const { fromUser, message } = data

      useSocketStore().setChat(data)
      if (data.userId != useUserStore().userId) {
        ElNotification({
          title: fromUser.nickName,
          message: message,
          type: 'success',
          duration: 3000
        })
        webNotify({ title: '来自：(From:)' + fromUser.nickName, body: message, icon: gongaoIcon })
      }
    })

    connection.on('onlineInfo', (data) => {
      useSocketStore().getOnlineInfo(data)
    })

    connection.on(MsgType.LogOut, () => {
      useUserStore()
        .logOut()
        .then(() => {
          ElMessageBox.alert(`你的账号已在其他设备登录，如果不是你的操作请尽快修改密码(Your account has been logged in on another device, if it is not your operation please change your password as soon as possible)`, 'Warnning', {
            confirmButtonText: '确定(Confirm)',
            callback: () => {
              location.href = import.meta.env.VITE_APP_ROUTER_PREFIX + 'index'
            }
          })
        })
    })
  }
}
const MsgType = {
  M001: 'onlineNum',
  M002: 'connId',
  LogOut: 'logOut'
}
