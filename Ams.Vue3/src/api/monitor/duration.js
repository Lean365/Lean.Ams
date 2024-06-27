import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 用户在线时长分页查询
* @param {查询条件} data
*/
export function listDurationLog(query) {
  return request({
    url: 'monitor/duration/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增用户在线时长
* @param data
*/
export function addDurationLog(data) {
  return request({
    url: 'monitor/duration',
    method: 'post',
    data: data,
  })
}
/**
* 获取用户在线时长详情
* @param {Id}
*/
export function getDurationLog(id) {
  return request({
    url: 'monitor/duration/' + id,
    method: 'get'
  })
}

/**
* 删除用户在线时长
* @param {主键} pid
*/
export function delDurationLog(pid) {
  return request({
    url: 'monitor/duration/delete/' + pid,
    method: 'delete'
  })
}
// 导出用户在线时长
export async function exportDurationLog(query) {
  await downFile('monitor/duration/export', { ...query })
}
