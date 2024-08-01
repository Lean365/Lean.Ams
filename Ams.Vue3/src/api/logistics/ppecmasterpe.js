import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 制技分页查询
 * @param {查询条件} data
 */
export function listPpEcMasterPe(query) {
  return request({
    url: 'Logistics/PpEcMasterPe/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增制技
 * @param data
 */
export function addPpEcMasterPe(data) {
  return request({
    url: 'Logistics/PpEcMasterPe',
    method: 'post',
    data: data,
  })
}
/**
 * 修改制技
 * @param data
 */
export function updatePpEcMasterPe(data) {
  return request({
    url: 'Logistics/PpEcMasterPe',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取制技详情
 * @param {Id}
 */
export function getPpEcMasterPe(id) {
  return request({
    url: 'Logistics/PpEcMasterPe/' + id,
    method: 'get'
  })
}

/**
 * 删除制技
 * @param {主键} pid
 */
export function delPpEcMasterPe(pid) {
  return request({
    url: 'Logistics/PpEcMasterPe/delete/' + pid,
    method: 'delete'
  })
}
// 导出制技
export async function exportPpEcMasterPe(query) {
  await downFile('Logistics/PpEcMasterPe/export', { ...query })
}
