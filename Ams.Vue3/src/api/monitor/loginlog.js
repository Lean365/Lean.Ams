import request from '@/utils/request'

// 查询登录日志列表
export function list(query) {
  return request({
    url: 'monitor/login/list',
    method: 'get',
    params: query
  })
}

// 查询我的登录日志列表
export function queryMylist(query) {
  return request({
    url: 'monitor/login/mylist',
    method: 'get',
    params: query
  })
}

// 删除登录日志
export function delLoginLog(infoId) {
  return request({
    url: 'monitor/login/' + infoId,
    method: 'delete'
  })
}

// 清空登录日志
export function cleanLoginLog() {
  return request({
    url: 'monitor/login/clean',
    method: 'delete'
  })
}

// 导出登录日志
export function exportLoginLog(query) {
  return request({
    url: 'monitor/login/export',
    method: 'get',
    params: query
  })
}
