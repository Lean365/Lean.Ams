import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 费用预算分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetExpense(query) {
  return request({
    url: 'Accounting/FicoBudgetExpense/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增费用预算
 * @param data
 */
export function addFicoBudgetExpense(data) {
  return request({
    url: 'Accounting/FicoBudgetExpense',
    method: 'post',
    data: data,
  })
}
/**
 * 修改费用预算
 * @param data
 */
export function updateFicoBudgetExpense(data) {
  return request({
    url: 'Accounting/FicoBudgetExpense',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取费用预算详情
 * @param {Id}
 */
export function getFicoBudgetExpense(id) {
  return request({
    url: 'Accounting/FicoBudgetExpense/' + id,
    method: 'get'
  })
}

/**
 * 删除费用预算
 * @param {主键} pid
 */
export function delFicoBudgetExpense(pid) {
  return request({
    url: 'Accounting/FicoBudgetExpense/delete/' + pid,
    method: 'delete'
  })
}
// 导出费用预算
export async function exportFicoBudgetExpense(query) {
  await downFile('Accounting/FicoBudgetExpense/export', { ...query })
}
