import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 工资率分页查询
* @param {查询条件} data
*/
export function listWageRates(query) {
  return request({
    url: 'accounting/WageRates/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增工资率
* @param data
*/
export function addWageRates(data) {
  return request({
    url: 'accounting/WageRates',
    method: 'post',
    data: data,
  })
}
/**
* 修改工资率
* @param data
*/
export function updateWageRates(data) {
  return request({
    url: 'accounting/WageRates',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取工资率详情
* @param {Id}
*/
export function getWageRates(id) {
  return request({
    url: 'accounting/WageRates/' + id,
    method: 'get'
  })
}

/**
* 删除工资率
* @param {主键} pid
*/
export function delWageRates(pid) {
  return request({
    url: 'accounting/WageRates/delete/' + pid,
    method: 'delete'
  })
}
// 导出工资率
export async function exportWageRates(query) {
  await downFile('accounting/WageRates/export', { ...query })
}
