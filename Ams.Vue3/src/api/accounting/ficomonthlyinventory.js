import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 月度存货分页查询
 * @param {查询条件} data
 */
export function listFicoMonthlyInventory(query) {
  return request({
    url: 'Accounting/FicoMonthlyInventory/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增月度存货
 * @param data
 */
export function addFicoMonthlyInventory(data) {
  return request({
    url: 'Accounting/FicoMonthlyInventory',
    method: 'post',
    data: data,
  })
}
/**
 * 修改月度存货
 * @param data
 */
export function updateFicoMonthlyInventory(data) {
  return request({
    url: 'Accounting/FicoMonthlyInventory',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取月度存货详情
 * @param {Id}
 */
export function getFicoMonthlyInventory(id) {
  return request({
    url: 'Accounting/FicoMonthlyInventory/' + id,
    method: 'get'
  })
}

/**
 * 删除月度存货
 * @param {主键} pid
 */
export function delFicoMonthlyInventory(pid) {
  return request({
    url: 'Accounting/FicoMonthlyInventory/delete/' + pid,
    method: 'delete'
  })
}
// 导出月度存货
export async function exportFicoMonthlyInventory(query) {
  await downFile('Accounting/FicoMonthlyInventory/export', { ...query })
}
