import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 组立不良ma分页查询
 * @param {查询条件} data
 */
export function listPpRepairAssyMa(query) {
  return request({
    url: 'Logistics/PpRepairAssyMa/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增组立不良ma
 * @param data
 */
export function addPpRepairAssyMa(data) {
  return request({
    url: 'Logistics/PpRepairAssyMa',
    method: 'post',
    data: data,
  })
}
/**
 * 修改组立不良ma
 * @param data
 */
export function updatePpRepairAssyMa(data) {
  return request({
    url: 'Logistics/PpRepairAssyMa',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取组立不良ma详情
 * @param {Id}
 */
export function getPpRepairAssyMa(id) {
  return request({
    url: 'Logistics/PpRepairAssyMa/' + id,
    method: 'get'
  })
}

/**
 * 删除组立不良ma
 * @param {主键} pid
 */
export function delPpRepairAssyMa(pid) {
  return request({
    url: 'Logistics/PpRepairAssyMa/delete/' + pid,
    method: 'delete'
  })
}
// 导出组立不良ma
export async function exportPpRepairAssyMa(query) {
  await downFile('Logistics/PpRepairAssyMa/export', { ...query })
}
