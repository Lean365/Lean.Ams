import request from '@/utils/request'

// 查询登录日志列表
export function list(query) {
  return request({
    url: '/monitor/login/list',
    method: 'get',
    params: query
  })
}

// 删除登录日志
export function delLogLogin(infoId) {
  return request({
    url: '/monitor/login/' + infoId,
    method: 'delete'
  })
}

// 清空登录日志
export function cleanLogLogin() {
  return request({
    url: '/monitor/login/clean',
    method: 'delete'
  })
}

// 导出登录日志
export function exportLogLogin(query) {
  return request({
    url: '/monitor/login/export',
    method: 'get',
    params: query
  })
}
// 登录日志统计查询
export function statiLogLogin(query) {
  return request({
    url: '/monitor/login/statiLogLogin',
    method: 'get',
    params: query
  })
}

