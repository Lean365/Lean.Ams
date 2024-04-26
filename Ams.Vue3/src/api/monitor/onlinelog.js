import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 用户在线时长分页查询
* @param {查询条件} data
*/
export function listOnlineLog(query) {
  return request({
    url: '/monitor/online/log/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增用户在线时长
* @param data
*/
export function addOnlineLog(data) {
  return request({
    url: '/monitor/online/log',
    method: 'post',
    data: data,
  })
}
/**
* 获取用户在线时长详情
* @param {Id}
*/
export function getOnlineLog(id) {
  return request({
    url: '/monitor/online/log/' + id,
    method: 'get'
  })
}

/**
* 删除用户在线时长
* @param {主键} pid
*/
export function delOnlineLog(pid) {
  return request({
    url: '/monitor/online/log/delete/' + pid,
    method: 'delete'
  })
}
// 导出用户在线时长
export async function exportOnlineLog(query) {
  await downFile('/monitor/online/log/export', { ...query })
}
