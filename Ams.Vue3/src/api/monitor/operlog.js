import request from '@/utils/request'
import QS from 'qs'

// 查询操作日志列表
export function list(query) {
  return request({
    url: 'monitor/oper/list',
    method: 'get',
    params: query,
    paramsSerializer: function (params) {
      return QS.stringify(params, { indices: false })
    }
  })
}

// 删除操作日志
export function delOperlog(operId) {
  return request({
    url: 'monitor/oper/' + operId,
    method: 'delete'
  })
}

// 清空操作日志
export function cleanOperlog() {
  return request({
    url: 'monitor/oper/clean',
    method: 'delete'
  })
}

// 导出操作日志
export function exportOperlog(query) {
  return request({
    url: 'monitor/oper/export',
    method: 'get',
    params: query
  })
}
