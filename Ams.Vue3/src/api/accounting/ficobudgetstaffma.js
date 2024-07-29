import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 人员预算分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetStaffMa(query) {
  return request({
    url: 'Accounting/FicoBudgetStaffMa/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增人员预算
 * @param data
 */
export function addFicoBudgetStaffMa(data) {
  return request({
    url: 'Accounting/FicoBudgetStaffMa',
    method: 'post',
    data: data,
  })
}
/**
 * 修改人员预算
 * @param data
 */
export function updateFicoBudgetStaffMa(data) {
  return request({
    url: 'Accounting/FicoBudgetStaffMa',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取人员预算详情
 * @param {Id}
 */
export function getFicoBudgetStaffMa(id) {
  return request({
    url: 'Accounting/FicoBudgetStaffMa/' + id,
    method: 'get'
  })
}

/**
 * 删除人员预算
 * @param {主键} pid
 */
export function delFicoBudgetStaffMa(pid) {
  return request({
    url: 'Accounting/FicoBudgetStaffMa/delete/' + pid,
    method: 'delete'
  })
}
// 导出人员预算
export async function exportFicoBudgetStaffMa(query) {
  await downFile('Accounting/FicoBudgetStaffMa/export', { ...query })
}
