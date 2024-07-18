import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 加班预算分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetOvertime(query) {
  return request({
    url: 'Accounting/FicoBudgetOvertime/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增加班预算
 * @param data
 */
export function addFicoBudgetOvertime(data) {
  return request({
    url: 'Accounting/FicoBudgetOvertime',
    method: 'post',
    data: data,
  })
}
/**
 * 修改加班预算
 * @param data
 */
export function updateFicoBudgetOvertime(data) {
  return request({
    url: 'Accounting/FicoBudgetOvertime',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取加班预算详情
 * @param {Id}
 */
export function getFicoBudgetOvertime(id) {
  return request({
    url: 'Accounting/FicoBudgetOvertime/' + id,
    method: 'get'
  })
}

/**
 * 删除加班预算
 * @param {主键} pid
 */
export function delFicoBudgetOvertime(pid) {
  return request({
    url: 'Accounting/FicoBudgetOvertime/delete/' + pid,
    method: 'delete'
  })
}
// 导出加班预算
export async function exportFicoBudgetOvertime(query) {
  await downFile('Accounting/FicoBudgetOvertime/export', { ...query })
}
