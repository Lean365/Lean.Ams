import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 费用预算分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetExpenseSlv(query) {
  return request({
    url: 'Accounting/FicoBudgetExpenseSlv/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增费用预算
 * @param data
 */
export function addFicoBudgetExpenseSlv(data) {
  return request({
    url: 'Accounting/FicoBudgetExpenseSlv',
    method: 'post',
    data: data,
  })
}
/**
 * 修改费用预算
 * @param data
 */
export function updateFicoBudgetExpenseSlv(data) {
  return request({
    url: 'Accounting/FicoBudgetExpenseSlv',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取费用预算详情
 * @param {Id}
 */
export function getFicoBudgetExpenseSlv(id) {
  return request({
    url: 'Accounting/FicoBudgetExpenseSlv/' + id,
    method: 'get'
  })
}

/**
 * 删除费用预算
 * @param {主键} pid
 */
export function delFicoBudgetExpenseSlv(pid) {
  return request({
    url: 'Accounting/FicoBudgetExpenseSlv/delete/' + pid,
    method: 'delete'
  })
}
// 导出费用预算
export async function exportFicoBudgetExpenseSlv(query) {
  await downFile('Accounting/FicoBudgetExpenseSlv/export', { ...query })
}
