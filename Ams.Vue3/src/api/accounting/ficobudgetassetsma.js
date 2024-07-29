import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 资产预算分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetAssetsMa(query) {
  return request({
    url: 'Accounting/FicoBudgetAssetsMa/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增资产预算
 * @param data
 */
export function addFicoBudgetAssetsMa(data) {
  return request({
    url: 'Accounting/FicoBudgetAssetsMa',
    method: 'post',
    data: data,
  })
}
/**
 * 修改资产预算
 * @param data
 */
export function updateFicoBudgetAssetsMa(data) {
  return request({
    url: 'Accounting/FicoBudgetAssetsMa',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取资产预算详情
 * @param {Id}
 */
export function getFicoBudgetAssetsMa(id) {
  return request({
    url: 'Accounting/FicoBudgetAssetsMa/' + id,
    method: 'get'
  })
}

/**
 * 删除资产预算
 * @param {主键} pid
 */
export function delFicoBudgetAssetsMa(pid) {
  return request({
    url: 'Accounting/FicoBudgetAssetsMa/delete/' + pid,
    method: 'delete'
  })
}
// 导出资产预算
export async function exportFicoBudgetAssetsMa(query) {
  await downFile('Accounting/FicoBudgetAssetsMa/export', { ...query })
}
