import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 部管分页查询
 * @param {查询条件} data
 */
export function listPpEcMasterMm(query) {
  return request({
    url: 'Logistics/PpEcMasterMm/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增部管
 * @param data
 */
export function addPpEcMasterMm(data) {
  return request({
    url: 'Logistics/PpEcMasterMm',
    method: 'post',
    data: data,
  })
}
/**
 * 修改部管
 * @param data
 */
export function updatePpEcMasterMm(data) {
  return request({
    url: 'Logistics/PpEcMasterMm',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取部管详情
 * @param {Id}
 */
export function getPpEcMasterMm(id) {
  return request({
    url: 'Logistics/PpEcMasterMm/' + id,
    method: 'get'
  })
}

/**
 * 删除部管
 * @param {主键} pid
 */
export function delPpEcMasterMm(pid) {
  return request({
    url: 'Logistics/PpEcMasterMm/delete/' + pid,
    method: 'delete'
  })
}
// 导出部管
export async function exportPpEcMasterMm(query) {
  await downFile('Logistics/PpEcMasterMm/export', { ...query })
}
