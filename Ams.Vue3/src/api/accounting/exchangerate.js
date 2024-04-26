import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 汇率表分页查询
* @param {查询条件} data
*/
export function listExchangeRate(query) {
  return request({
    url: 'accounting/ExchangeRate/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增汇率表
* @param data
*/
export function addExchangeRate(data) {
  return request({
    url: 'accounting/ExchangeRate',
    method: 'post',
    data: data,
  })
}
/**
* 修改汇率表
* @param data
*/
export function updateExchangeRate(data) {
  return request({
    url: 'accounting/ExchangeRate',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取汇率表详情
* @param {Id}
*/
export function getExchangeRate(id) {
  return request({
    url: 'accounting/ExchangeRate/' + id,
    method: 'get'
  })
}

/**
* 删除汇率表
* @param {主键} pid
*/
export function delExchangeRate(pid) {
  return request({
    url: 'accounting/ExchangeRate/delete/' + pid,
    method: 'delete'
  })
}
// 导出汇率表
export async function exportExchangeRate(query) {
  await downFile('accounting/ExchangeRate/export', { ...query })
}
