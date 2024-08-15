import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 预算实际明细分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetActualCost(query) {
  return request({
    url: 'Accounting/FicoBudgetActualCost/list',
    method: 'get',
    params: query,
  })
}

/**
 * 获取预算实际明细详情
 * @param {Id}
 */
export function getFicoBudgetActualCost(id) {
  return request({
    url: 'Accounting/FicoBudgetActualCost/' + id,
    method: 'get'
  })
}

// 导出预算实际明细
export async function exportFicoBudgetActualCost(query) {
  await downFile('Accounting/FicoBudgetActualCost/export', { ...query })
}
