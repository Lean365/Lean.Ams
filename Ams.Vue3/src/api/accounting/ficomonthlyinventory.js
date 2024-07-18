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
 * 获取月度存货详情
 * @param {Id}
 */
export function getFicoMonthlyInventory(id) {
  return request({
    url: 'Accounting/FicoMonthlyInventory/' + id,
    method: 'get'
  })
}

// 导出月度存货
export async function exportFicoMonthlyInventory(query) {
  await downFile('Accounting/FicoMonthlyInventory/export', { ...query })
}
