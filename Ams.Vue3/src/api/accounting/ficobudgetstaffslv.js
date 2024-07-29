import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 人员预算分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetStaffSlv(query) {
  return request({
    url: 'Accounting/FicoBudgetStaffSlv/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增人员预算
 * @param data
 */
export function addFicoBudgetStaffSlv(data) {
  return request({
    url: 'Accounting/FicoBudgetStaffSlv',
    method: 'post',
    data: data,
  })
}
/**
 * 修改人员预算
 * @param data
 */
export function updateFicoBudgetStaffSlv(data) {
  return request({
    url: 'Accounting/FicoBudgetStaffSlv',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取人员预算详情
 * @param {Id}
 */
export function getFicoBudgetStaffSlv(id) {
  return request({
    url: 'Accounting/FicoBudgetStaffSlv/' + id,
    method: 'get'
  })
}

/**
 * 删除人员预算
 * @param {主键} pid
 */
export function delFicoBudgetStaffSlv(pid) {
  return request({
    url: 'Accounting/FicoBudgetStaffSlv/delete/' + pid,
    method: 'delete'
  })
}
// 导出人员预算
export async function exportFicoBudgetStaffSlv(query) {
  await downFile('Accounting/FicoBudgetStaffSlv/export', { ...query })
}
