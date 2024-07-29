import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 预算科目分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetAccountingSlv(query) {
  return request({
    url: 'Accounting/FicoBudgetAccountingSlv/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增预算科目
 * @param data
 */
export function addFicoBudgetAccountingSlv(data) {
  return request({
    url: 'Accounting/FicoBudgetAccountingSlv',
    method: 'post',
    data: data,
  })
}
/**
 * 修改预算科目
 * @param data
 */
export function updateFicoBudgetAccountingSlv(data) {
  return request({
    url: 'Accounting/FicoBudgetAccountingSlv',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取预算科目详情
 * @param {Id}
 */
export function getFicoBudgetAccountingSlv(id) {
  return request({
    url: 'Accounting/FicoBudgetAccountingSlv/' + id,
    method: 'get'
  })
}

/**
 * 删除预算科目
 * @param {主键} pid
 */
export function delFicoBudgetAccountingSlv(pid) {
  return request({
    url: 'Accounting/FicoBudgetAccountingSlv/delete/' + pid,
    method: 'delete'
  })
}
// 导出预算科目
export async function exportFicoBudgetAccountingSlv(query) {
  await downFile('Accounting/FicoBudgetAccountingSlv/export', { ...query })
}
