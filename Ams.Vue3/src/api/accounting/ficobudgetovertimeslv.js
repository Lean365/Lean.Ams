import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 加班预算分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetOvertimeSlv(query) {
  return request({
    url: 'Accounting/FicoBudgetOvertimeSlv/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增加班预算
 * @param data
 */
export function addFicoBudgetOvertimeSlv(data) {
  return request({
    url: 'Accounting/FicoBudgetOvertimeSlv',
    method: 'post',
    data: data,
  })
}
/**
 * 修改加班预算
 * @param data
 */
export function updateFicoBudgetOvertimeSlv(data) {
  return request({
    url: 'Accounting/FicoBudgetOvertimeSlv',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取加班预算详情
 * @param {Id}
 */
export function getFicoBudgetOvertimeSlv(id) {
  return request({
    url: 'Accounting/FicoBudgetOvertimeSlv/' + id,
    method: 'get'
  })
}

/**
 * 删除加班预算
 * @param {主键} pid
 */
export function delFicoBudgetOvertimeSlv(pid) {
  return request({
    url: 'Accounting/FicoBudgetOvertimeSlv/delete/' + pid,
    method: 'delete'
  })
}
// 导出加班预算
export async function exportFicoBudgetOvertimeSlv(query) {
  await downFile('Accounting/FicoBudgetOvertimeSlv/export', { ...query })
}
