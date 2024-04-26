import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 从客诉管理分页查询
* @param {查询条件} data
*/
export function listComplaintsSlave(query) {
  return request({
    url: 'logistics/ComplaintsSlave/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增从客诉管理
* @param data
*/
export function addComplaintsSlave(data) {
  return request({
    url: 'logistics/ComplaintsSlave',
    method: 'post',
    data: data,
  })
}
/**
* 修改从客诉管理
* @param data
*/
export function updateComplaintsSlave(data) {
  return request({
    url: 'logistics/ComplaintsSlave',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取从客诉管理详情
* @param {Id}
*/
export function getComplaintsSlave(id) {
  return request({
    url: 'logistics/ComplaintsSlave/' + id,
    method: 'get'
  })
}

/**
* 删除从客诉管理
* @param {主键} pid
*/
export function delComplaintsSlave(pid) {
  return request({
    url: 'logistics/ComplaintsSlave/delete/' + pid,
    method: 'delete'
  })
}
// 导出从客诉管理
export async function exportComplaintsSlave(query) {
  await downFile('logistics/ComplaintsSlave/export', { ...query })
}
