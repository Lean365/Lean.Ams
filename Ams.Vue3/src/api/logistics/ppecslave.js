import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 设变明细分页查询
 * @param {查询条件} data
 */
export function listPpEcSlave(query) {
  return request({
    url: 'Logistics/PpEcSlave/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增设变明细
 * @param data
 */
export function addPpEcSlave(data) {
  return request({
    url: 'Logistics/PpEcSlave',
    method: 'post',
    data: data,
  })
}
/**
 * 修改设变明细
 * @param data
 */
export function updatePpEcSlave(data) {
  return request({
    url: 'Logistics/PpEcSlave',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取设变明细详情
 * @param {Id}
 */
export function getPpEcSlave(id) {
  return request({
    url: 'Logistics/PpEcSlave/' + id,
    method: 'get'
  })
}

/**
 * 删除设变明细
 * @param {主键} pid
 */
export function delPpEcSlave(pid) {
  return request({
    url: 'Logistics/PpEcSlave/delete/' + pid,
    method: 'delete'
  })
}
// 导出设变明细
export async function exportPpEcSlave(query) {
  await downFile('Logistics/PpEcSlave/export', { ...query })
}
