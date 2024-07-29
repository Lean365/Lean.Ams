import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 费用预算分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetExpenseMa(query) {
  return request({
    url: 'Accounting/FicoBudgetExpenseMa/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增费用预算
 * @param data
 */
export function addFicoBudgetExpenseMa(data) {
  return request({
    url: 'Accounting/FicoBudgetExpenseMa',
    method: 'post',
    data: data,
  })
}
/**
 * 修改费用预算
 * @param data
 */
export function updateFicoBudgetExpenseMa(data) {
  return request({
    url: 'Accounting/FicoBudgetExpenseMa',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取费用预算详情
 * @param {Id}
 */
export function getFicoBudgetExpenseMa(id) {
  return request({
    url: 'Accounting/FicoBudgetExpenseMa/' + id,
    method: 'get'
  })
}

/**
 * 删除费用预算
 * @param {主键} pid
 */
export function delFicoBudgetExpenseMa(pid) {
  return request({
    url: 'Accounting/FicoBudgetExpenseMa/delete/' + pid,
    method: 'delete'
  })
}
// 导出费用预算
export async function exportFicoBudgetExpenseMa(query) {
  await downFile('Accounting/FicoBudgetExpenseMa/export', { ...query })
}
