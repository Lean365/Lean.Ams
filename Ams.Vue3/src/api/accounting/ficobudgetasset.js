import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 资产预算分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetAsset(query) {
  return request({
    url: 'Accounting/FicoBudgetAsset/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增资产预算
 * @param data
 */
export function addFicoBudgetAsset(data) {
  return request({
    url: 'Accounting/FicoBudgetAsset',
    method: 'post',
    data: data,
  })
}
/**
 * 修改资产预算
 * @param data
 */
export function updateFicoBudgetAsset(data) {
  return request({
    url: 'Accounting/FicoBudgetAsset',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取资产预算详情
 * @param {Id}
 */
export function getFicoBudgetAsset(id) {
  return request({
    url: 'Accounting/FicoBudgetAsset/' + id,
    method: 'get'
  })
}

/**
 * 删除资产预算
 * @param {主键} pid
 */
export function delFicoBudgetAsset(pid) {
  return request({
    url: 'Accounting/FicoBudgetAsset/delete/' + pid,
    method: 'delete'
  })
}
// 导出资产预算
export async function exportFicoBudgetAsset(query) {
  await downFile('Accounting/FicoBudgetAsset/export', { ...query })
}
