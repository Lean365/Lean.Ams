import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 币种汇率分页查询
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
 * 新增币种汇率
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
 * 修改币种汇率
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
 * 获取币种汇率详情
 * @param {Id}
 */
export function getFicoExchangeRate(id) {
  return request({
    url: 'Accounting/FicoExchangeRate/' + id,
    method: 'get'
  })
}

/**
 * 删除币种汇率
 * @param {主键} pid
 */
export function delFicoExchangeRate(pid) {
  return request({
    url: 'Accounting/FicoExchangeRate/delete/' + pid,
    method: 'delete'
  })
}
// 导出币种汇率
export async function exportFicoExchangeRate(query) {
  await downFile('Accounting/FicoExchangeRate/export', { ...query })
}
