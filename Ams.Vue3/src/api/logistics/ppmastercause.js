import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 原因类别分页查询
 * @param {查询条件} data
 */
export function listPpMasterCause(query) {
  return request({
    url: 'Logistics/PpMasterCause/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增原因类别
 * @param data
 */
export function addPpMasterCause(data) {
  return request({
    url: 'Logistics/PpMasterCause',
    method: 'post',
    data: data,
  })
}
/**
 * 修改原因类别
 * @param data
 */
export function updatePpMasterCause(data) {
  return request({
    url: 'Logistics/PpMasterCause',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取原因类别详情
 * @param {Id}
 */
export function getPpMasterCause(id) {
  return request({
    url: 'Logistics/PpMasterCause/' + id,
    method: 'get'
  })
}

/**
 * 删除原因类别
 * @param {主键} pid
 */
export function delPpMasterCause(pid) {
  return request({
    url: 'Logistics/PpMasterCause/delete/' + pid,
    method: 'delete'
  })
}
// 导出原因类别
export async function exportPpMasterCause(query) {
  await downFile('Logistics/PpMasterCause/export', { ...query })
}
