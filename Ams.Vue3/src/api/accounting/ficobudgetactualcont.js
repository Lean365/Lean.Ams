import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 预算实际明细分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetActualCont(query) {
  return request({
    url: 'Accounting/FicoBudgetActualCont/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增预算实际明细
 * @param data
 */
export function addFicoBudgetActualCont(data) {
  return request({
    url: 'Accounting/FicoBudgetActualCont',
    method: 'post',
    data: data,
  })
}
/**
 * 修改预算实际明细
 * @param data
 */
export function updateFicoBudgetActualCont(data) {
  return request({
    url: 'Accounting/FicoBudgetActualCont',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取预算实际明细详情
 * @param {Id}
 */
export function getFicoBudgetActualCont(id) {
  return request({
    url: 'Accounting/FicoBudgetActualCont/' + id,
    method: 'get'
  })
}

/**
 * 删除预算实际明细
 * @param {主键} pid
 */
export function delFicoBudgetActualCont(pid) {
  return request({
    url: 'Accounting/FicoBudgetActualCont/delete/' + pid,
    method: 'delete'
  })
}
// 导出预算实际明细
export async function exportFicoBudgetActualCont(query) {
  await downFile('Accounting/FicoBudgetActualCont/export', { ...query })
}
