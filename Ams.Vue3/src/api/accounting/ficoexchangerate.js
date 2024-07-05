import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 汇率表分页查询
 * @param {查询条件} data
 */
export function listFicoExchangeRate(query) {
  return request({
    url: 'Accounting/FicoExchangeRate/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增汇率表
 * @param data
 */
export function addFicoExchangeRate(data) {
  return request({
    url: 'Accounting/FicoExchangeRate',
    method: 'post',
    data: data,
  })
}
/**
 * 修改汇率表
 * @param data
 */
export function updateFicoExchangeRate(data) {
  return request({
    url: 'Accounting/FicoExchangeRate',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取汇率表详情
 * @param {Id}
 */
export function getFicoExchangeRate(id) {
  return request({
    url: 'Accounting/FicoExchangeRate/' + id,
    method: 'get'
  })
}

/**
 * 删除汇率表
 * @param {主键} pid
 */
export function delFicoExchangeRate(pid) {
  return request({
    url: 'Accounting/FicoExchangeRate/delete/' + pid,
    method: 'delete'
  })
}
// 导出汇率表
export async function exportFicoExchangeRate(query) {
  await downFile('Accounting/FicoExchangeRate/export', { ...query })
}
