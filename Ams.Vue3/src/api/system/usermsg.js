import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 用户系统消息分页查询
 * @param {查询条件} data
 */
export function listUserMsg(query) {
  return request({
    url: 'system/user/msg/list',
    method: 'get',
    params: query
  })
}

/**
 * 用户系统消息分页查询
 * @param {查询条件} data
 */
export function listMyUserMsg(query) {
  return request({
    url: 'system/user/msg/mylist',
    method: 'get',
    params: query
  })
}

/**
 * 新增用户系统消息
 * @param data
 */
export function addUserMsg(data) {
  return request({
    url: 'system/user/msg',
    method: 'post',
    data: data
  })
}
/**
 * 获取用户系统消息详情
 * @param {Id}
 */
export function getUserMsg(id) {
  return request({
    url: 'system/user/msg/' + id,
    method: 'get'
  })
}

/**
 * 删除用户系统消息
 * @param {主键} pid
 */
export function delUserMsg(pid) {
  return request({
    url: 'system/user/msg/delete/' + pid,
    method: 'delete'
  })
}
// 清空用户系统消息
export function clearUserMsg() {
  return request({
    url: 'system/user/msg/clean',
    method: 'delete'
  })
}
// 导出用户系统消息
export async function exportUserMsg(query) {
  await downFile('system/user/msg/export', { ...query })
}

/**
 * 已读用户系统消息
 * @param data
 */
export function readUserMsg(msgId, msgType) {
  return request({
    url: 'system/user/msg/read/' + msgId + '/' + msgType,
    method: 'post',
    params: { msgType }
  })
}
