import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 修理明细分页查询
 * @param {查询条件} data
 */
export function listPpRepairPcbaSlv(query) {
  return request({
    url: 'Logistics/PpRepairPcbaSlv/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增修理明细
 * @param data
 */
export function addPpRepairPcbaSlv(data) {
  return request({
    url: 'Logistics/PpRepairPcbaSlv',
    method: 'post',
    data: data,
  })
}
/**
 * 修改修理明细
 * @param data
 */
export function updatePpRepairPcbaSlv(data) {
  return request({
    url: 'Logistics/PpRepairPcbaSlv',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取修理明细详情
 * @param {Id}
 */
export function getPpRepairPcbaSlv(id) {
  return request({
    url: 'Logistics/PpRepairPcbaSlv/' + id,
    method: 'get'
  })
}

/**
 * 删除修理明细
 * @param {主键} pid
 */
export function delPpRepairPcbaSlv(pid) {
  return request({
    url: 'Logistics/PpRepairPcbaSlv/delete/' + pid,
    method: 'delete'
  })
}
// 导出修理明细
export async function exportPpRepairPcbaSlv(query) {
  await downFile('Logistics/PpRepairPcbaSlv/export', { ...query })
}
