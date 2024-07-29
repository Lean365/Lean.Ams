import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 预算科目分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetAccountingMa(query) {
  return request({
    url: 'Accounting/FicoBudgetAccountingMa/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增预算科目
 * @param data
 */
export function addFicoBudgetAccountingMa(data) {
  return request({
    url: 'Accounting/FicoBudgetAccountingMa',
    method: 'post',
    data: data,
  })
}
/**
 * 修改预算科目
 * @param data
 */
export function updateFicoBudgetAccountingMa(data) {
  return request({
    url: 'Accounting/FicoBudgetAccountingMa',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取预算科目详情
 * @param {Id}
 */
export function getFicoBudgetAccountingMa(id) {
  return request({
    url: 'Accounting/FicoBudgetAccountingMa/' + id,
    method: 'get'
  })
}

/**
 * 删除预算科目
 * @param {主键} pid
 */
export function delFicoBudgetAccountingMa(pid) {
  return request({
    url: 'Accounting/FicoBudgetAccountingMa/delete/' + pid,
    method: 'delete'
  })
}
// 导出预算科目
export async function exportFicoBudgetAccountingMa(query) {
  await downFile('Accounting/FicoBudgetAccountingMa/export', { ...query })
}
