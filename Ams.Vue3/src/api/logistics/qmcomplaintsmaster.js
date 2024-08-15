import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 主客诉管理分页查询
 * @param {查询条件} data
 */
export function listQmComplaintsMaster(query) {
  return request({
    url: 'Logistics/QmComplaintsMaster/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增主客诉管理
 * @param data
 */
export function addQmComplaintsMaster(data) {
  return request({
    url: 'Logistics/QmComplaintsMaster',
    method: 'post',
    data: data,
  })
}
/**
 * 修改主客诉管理
 * @param data
 */
export function updateQmComplaintsMaster(data) {
  return request({
    url: 'Logistics/QmComplaintsMaster',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取主客诉管理详情
 * @param {Id}
 */
export function getQmComplaintsMaster(id) {
  return request({
    url: 'Logistics/QmComplaintsMaster/' + id,
    method: 'get'
  })
}

/**
 * 删除主客诉管理
 * @param {主键} pid
 */
export function delQmComplaintsMaster(pid) {
  return request({
    url: 'Logistics/QmComplaintsMaster/delete/' + pid,
    method: 'delete'
  })
}
// 导出主客诉管理
export async function exportQmComplaintsMaster(query) {
  await downFile('Logistics/QmComplaintsMaster/export', { ...query })
}
