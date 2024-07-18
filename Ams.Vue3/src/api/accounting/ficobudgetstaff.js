import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 人员预算分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetStaff(query) {
  return request({
    url: 'Accounting/FicoBudgetStaff/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增人员预算
 * @param data
 */
export function addFicoBudgetStaff(data) {
  return request({
    url: 'Accounting/FicoBudgetStaff',
    method: 'post',
    data: data,
  })
}
/**
 * 修改人员预算
 * @param data
 */
export function updateFicoBudgetStaff(data) {
  return request({
    url: 'Accounting/FicoBudgetStaff',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取人员预算详情
 * @param {Id}
 */
export function getFicoBudgetStaff(id) {
  return request({
    url: 'Accounting/FicoBudgetStaff/' + id,
    method: 'get'
  })
}

/**
 * 删除人员预算
 * @param {主键} pid
 */
export function delFicoBudgetStaff(pid) {
  return request({
    url: 'Accounting/FicoBudgetStaff/delete/' + pid,
    method: 'delete'
  })
}
// 导出人员预算
export async function exportFicoBudgetStaff(query) {
  await downFile('Accounting/FicoBudgetStaff/export', { ...query })
}
