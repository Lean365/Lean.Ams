import request from '@/utils/request'

// 查询在线用户列表
export function listOnline(query) {
  return request({
    url: '/monitor/onlineuser/list',
    method: 'get',
    params: query
  })
}

// 强退用户
export function forceLogout(data) {
  return request({
    url: '/monitor/onlineuser/force',
    method: 'delete',
    data: data
  })
}

// 批量强退用户
export function forceLogoutAll(data) {
  return request({
    url: '/monitor/onlineuser/batchForce',
    method: 'delete',
    data: data
  })
}
