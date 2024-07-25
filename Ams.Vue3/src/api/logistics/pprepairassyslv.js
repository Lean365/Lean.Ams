import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 组立不良slv分页查询
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
 * 新增组立不良slv
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
 * 修改组立不良slv
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
 * 获取组立不良slv详情
 * @param {Id}
 */
export function getPpRepairAssySlv(id) {
  return request({
    url: 'Logistics/PpRepairAssySlv/' + id,
    method: 'get'
  })
}

/**
 * 删除组立不良slv
 * @param {主键} pid
 */
export function delPpRepairAssySlv(pid) {
  return request({
    url: 'Logistics/PpRepairAssySlv/delete/' + pid,
    method: 'delete'
  })
}
// 导出组立不良slv
export async function exportPpRepairAssySlv(query) {
  await downFile('Logistics/PpRepairAssySlv/export', { ...query })
}
