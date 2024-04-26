import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 主客诉管理分页查询
* @param {查询条件} data
*/
export function listComplaintsMaster(query) {
  return request({
    url: 'logistics/ComplaintsMaster/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增主客诉管理
* @param data
*/
export function addComplaintsMaster(data) {
  return request({
    url: 'logistics/ComplaintsMaster',
    method: 'post',
    data: data,
  })
}
/**
* 修改主客诉管理
* @param data
*/
export function updateComplaintsMaster(data) {
  return request({
    url: 'logistics/ComplaintsMaster',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取主客诉管理详情
* @param {Id}
*/
export function getComplaintsMaster(id) {
  return request({
    url: 'logistics/ComplaintsMaster/' + id,
    method: 'get'
  })
}

/**
* 删除主客诉管理
* @param {主键} pid
*/
export function delComplaintsMaster(pid) {
  return request({
    url: 'logistics/ComplaintsMaster/delete/' + pid,
    method: 'delete'
  })
}
// 导出主客诉管理
export async function exportComplaintsMaster(query) {
  await downFile('logistics/ComplaintsMaster/export', { ...query })
}
