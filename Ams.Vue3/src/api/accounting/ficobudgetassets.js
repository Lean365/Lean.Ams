import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 资产预算分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetAssets(query) {
  return request({
    url: 'Accounting/FicoBudgetAssets/list',
    method: 'get',
    params: query,
  })
}

/**
 * 资产预算tree查询
 * @param {查询条件} data
 */
export function treelistFicoBudgetAssets(query) {
  return request({
    url: 'Accounting/FicoBudgetAssets/treelist',
    method: 'get',
    params: query,
  })
}
/**
 * 新增资产预算
 * @param data
 */
export function addFicoBudgetAssets(data) {
  return request({
    url: 'Accounting/FicoBudgetAssets',
    method: 'post',
    data: data,
  })
}
/**
 * 修改资产预算
 * @param data
 */
export function updateFicoBudgetAssets(data) {
  return request({
    url: 'Accounting/FicoBudgetAssets',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取资产预算详情
 * @param {Id}
 */
export function getFicoBudgetAssets(id) {
  return request({
    url: 'Accounting/FicoBudgetAssets/' + id,
    method: 'get'
  })
}

/**
 * 删除资产预算
 * @param {主键} pid
 */
export function delFicoBudgetAssets(pid) {
  return request({
    url: 'Accounting/FicoBudgetAssets/delete/' + pid,
    method: 'delete'
  })
}
// 导出资产预算
export async function exportFicoBudgetAssets(query) {
  await downFile('Accounting/FicoBudgetAssets/export', { ...query })
}
