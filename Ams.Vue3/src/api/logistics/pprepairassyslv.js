import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 不良明细分页查询
 * @param {查询条件} data
 */
export function listPpRepairAssySlv(query) {
  return request({
    url: 'Logistics/PpRepairAssySlv/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增不良明细
 * @param data
 */
export function addPpRepairAssySlv(data) {
  return request({
    url: 'Logistics/PpRepairAssySlv',
    method: 'post',
    data: data,
  })
}
/**
 * 修改不良明细
 * @param data
 */
export function updatePpRepairAssySlv(data) {
  return request({
    url: 'Logistics/PpRepairAssySlv',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取不良明细详情
 * @param {Id}
 */
export function getPpRepairAssySlv(id) {
  return request({
    url: 'Logistics/PpRepairAssySlv/' + id,
    method: 'get'
  })
}

/**
 * 删除不良明细
 * @param {主键} pid
 */
export function delPpRepairAssySlv(pid) {
  return request({
    url: 'Logistics/PpRepairAssySlv/delete/' + pid,
    method: 'delete'
  })
}
// 导出不良明细
export async function exportPpRepairAssySlv(query) {
  await downFile('Logistics/PpRepairAssySlv/export', { ...query })
}
