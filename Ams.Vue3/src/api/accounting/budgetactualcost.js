import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 预算实际明细分页查询
* @param {查询条件} data
*/
export function listBudgetActualCost(query) {
  return request({
    url: 'accounting/BudgetActualCost/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增预算实际明细
* @param data
*/
export function addBudgetActualCost(data) {
  return request({
    url: 'accounting/BudgetActualCost',
    method: 'post',
    data: data,
  })
}
/**
* 修改预算实际明细
* @param data
*/
export function updateBudgetActualCost(data) {
  return request({
    url: 'accounting/BudgetActualCost',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取预算实际明细详情
* @param {Id}
*/
export function getBudgetActualCost(id) {
  return request({
    url: 'accounting/BudgetActualCost/' + id,
    method: 'get'
  })
}

/**
* 删除预算实际明细
* @param {主键} pid
*/
export function delBudgetActualCost(pid) {
  return request({
    url: 'accounting/BudgetActualCost/delete/' + pid,
    method: 'delete'
  })
}
// 导出预算实际明细
export async function exportBudgetActualCost(query) {
  await downFile('accounting/BudgetActualCost/export', { ...query })
}
