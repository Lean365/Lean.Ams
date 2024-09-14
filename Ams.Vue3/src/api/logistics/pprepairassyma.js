import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 不良分页查询
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
 * 新增不良
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
 * 修改不良
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
 * 获取不良详情
 * @param {Id}
 */
export function getPpRepairAssyMa(id) {
  return request({
    url: 'Logistics/PpRepairAssyMa/' + id,
    method: 'get'
  })
}

/**
 * 删除不良
 * @param {主键} pid
 */
export function delPpRepairAssyMa(pid) {
  return request({
    url: 'Logistics/PpRepairAssyMa/delete/' + pid,
    method: 'delete'
  })
}
// 导出不良
export async function exportPpRepairAssyMa(query) {
  await downFile('Logistics/PpRepairAssyMa/export', { ...query })
}
