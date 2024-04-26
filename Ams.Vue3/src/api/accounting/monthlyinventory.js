import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 月度存货分页查询
* @param {查询条件} data
*/
export function listMonthlyInventory(query) {
  return request({
    url: 'accounting/MonthlyInventory/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增月度存货
* @param data
*/
export function addMonthlyInventory(data) {
  return request({
    url: 'accounting/MonthlyInventory',
    method: 'post',
    data: data,
  })
}
/**
* 修改月度存货
* @param data
*/
export function updateMonthlyInventory(data) {
  return request({
    url: 'accounting/MonthlyInventory',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取月度存货详情
* @param {Id}
*/
export function getMonthlyInventory(id) {
  return request({
    url: 'accounting/MonthlyInventory/' + id,
    method: 'get'
  })
}

/**
* 删除月度存货
* @param {主键} pid
*/
export function delMonthlyInventory(pid) {
  return request({
    url: 'accounting/MonthlyInventory/delete/' + pid,
    method: 'delete'
  })
}
// 导出月度存货
export async function exportMonthlyInventory(query) {
  await downFile('accounting/MonthlyInventory/export', { ...query })
}
