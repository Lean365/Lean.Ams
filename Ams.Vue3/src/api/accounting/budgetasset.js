import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 资产预算分页查询
* @param {查询条件} data
*/
export function listBudgetAsset(query) {
  return request({
    url: 'accounting/BudgetAsset/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增资产预算
* @param data
*/
export function addBudgetAsset(data) {
  return request({
    url: 'accounting/BudgetAsset',
    method: 'post',
    data: data,
  })
}
/**
* 修改资产预算
* @param data
*/
export function updateBudgetAsset(data) {
  return request({
    url: 'accounting/BudgetAsset',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取资产预算详情
* @param {Id}
*/
export function getBudgetAsset(id) {
  return request({
    url: 'accounting/BudgetAsset/' + id,
    method: 'get'
  })
}

/**
* 删除资产预算
* @param {主键} pid
*/
export function delBudgetAsset(pid) {
  return request({
    url: 'accounting/BudgetAsset/delete/' + pid,
    method: 'delete'
  })
}
// 导出资产预算
export async function exportBudgetAsset(query) {
  await downFile('accounting/BudgetAsset/export', { ...query })
}
