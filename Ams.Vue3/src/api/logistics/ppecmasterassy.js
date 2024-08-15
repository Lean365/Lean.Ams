import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 制一分页查询
 * @param {查询条件} data
 */
export function listPpEcMasterAssy(query) {
  return request({
    url: 'Logistics/PpEcMasterAssy/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增制一
 * @param data
 */
export function addPpEcMasterAssy(data) {
  return request({
    url: 'Logistics/PpEcMasterAssy',
    method: 'post',
    data: data,
  })
}
/**
 * 修改制一
 * @param data
 */
export function updatePpEcMasterAssy(data) {
  return request({
    url: 'Logistics/PpEcMasterAssy',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取制一详情
 * @param {Id}
 */
export function getPpEcMasterAssy(id) {
  return request({
    url: 'Logistics/PpEcMasterAssy/' + id,
    method: 'get'
  })
}

/**
 * 删除制一
 * @param {主键} pid
 */
export function delPpEcMasterAssy(pid) {
  return request({
    url: 'Logistics/PpEcMasterAssy/delete/' + pid,
    method: 'delete'
  })
}
// 导出制一
export async function exportPpEcMasterAssy(query) {
  await downFile('Logistics/PpEcMasterAssy/export', { ...query })
}
