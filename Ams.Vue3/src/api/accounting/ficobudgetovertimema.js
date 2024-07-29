import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 加班预算分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetOvertimeMa(query) {
  return request({
    url: 'Accounting/FicoBudgetOvertimeMa/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增加班预算
 * @param data
 */
export function addFicoBudgetOvertimeMa(data) {
  return request({
    url: 'Accounting/FicoBudgetOvertimeMa',
    method: 'post',
    data: data,
  })
}
/**
 * 修改加班预算
 * @param data
 */
export function updateFicoBudgetOvertimeMa(data) {
  return request({
    url: 'Accounting/FicoBudgetOvertimeMa',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取加班预算详情
 * @param {Id}
 */
export function getFicoBudgetOvertimeMa(id) {
  return request({
    url: 'Accounting/FicoBudgetOvertimeMa/' + id,
    method: 'get'
  })
}

/**
 * 删除加班预算
 * @param {主键} pid
 */
export function delFicoBudgetOvertimeMa(pid) {
  return request({
    url: 'Accounting/FicoBudgetOvertimeMa/delete/' + pid,
    method: 'delete'
  })
}
// 导出加班预算
export async function exportFicoBudgetOvertimeMa(query) {
  await downFile('Accounting/FicoBudgetOvertimeMa/export', { ...query })
}
