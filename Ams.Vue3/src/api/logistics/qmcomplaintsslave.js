import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 从客诉管理分页查询
 * @param {查询条件} data
 */
export function listQmComplaintsSlave(query) {
  return request({
    url: 'Logistics/QmComplaintsSlave/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增从客诉管理
 * @param data
 */
export function addQmComplaintsSlave(data) {
  return request({
    url: 'Logistics/QmComplaintsSlave',
    method: 'post',
    data: data,
  })
}
/**
 * 修改从客诉管理
 * @param data
 */
export function updateQmComplaintsSlave(data) {
  return request({
    url: 'Logistics/QmComplaintsSlave',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取从客诉管理详情
 * @param {Id}
 */
export function getQmComplaintsSlave(id) {
  return request({
    url: 'Logistics/QmComplaintsSlave/' + id,
    method: 'get'
  })
}

/**
 * 删除从客诉管理
 * @param {主键} pid
 */
export function delQmComplaintsSlave(pid) {
  return request({
    url: 'Logistics/QmComplaintsSlave/delete/' + pid,
    method: 'delete'
  })
}
// 导出从客诉管理
export async function exportQmComplaintsSlave(query) {
  await downFile('Logistics/QmComplaintsSlave/export', { ...query })
}
