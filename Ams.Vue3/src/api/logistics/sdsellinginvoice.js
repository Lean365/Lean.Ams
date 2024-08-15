import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 销售凭证分页查询
 * @param {查询条件} data
 */
export function listSdSellingInvoice(query) {
  return request({
    url: 'Logistics/SdSellingInvoice/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增销售凭证
 * @param data
 */
export function addSdSellingInvoice(data) {
  return request({
    url: 'Logistics/SdSellingInvoice',
    method: 'post',
    data: data,
  })
}
/**
 * 修改销售凭证
 * @param data
 */
export function updateSdSellingInvoice(data) {
  return request({
    url: 'Logistics/SdSellingInvoice',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取销售凭证详情
 * @param {Id}
 */
export function getSdSellingInvoice(id) {
  return request({
    url: 'Logistics/SdSellingInvoice/' + id,
    method: 'get'
  })
}

/**
 * 删除销售凭证
 * @param {主键} pid
 */
export function delSdSellingInvoice(pid) {
  return request({
    url: 'Logistics/SdSellingInvoice/delete/' + pid,
    method: 'delete'
  })
}
// 导出销售凭证
export async function exportSdSellingInvoice(query) {
  await downFile('Logistics/SdSellingInvoice/export', { ...query })
}
