import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 销售凭证分页查询
* @param {查询条件} data
*/
export function listSalesInvoice(query) {
  return request({
    url: 'logistics/SalesInvoice/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增销售凭证
* @param data
*/
export function addSalesInvoice(data) {
  return request({
    url: 'logistics/SalesInvoice',
    method: 'post',
    data: data,
  })
}
/**
* 修改销售凭证
* @param data
*/
export function updateSalesInvoice(data) {
  return request({
    url: 'logistics/SalesInvoice',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取销售凭证详情
* @param {Id}
*/
export function getSalesInvoice(id) {
  return request({
    url: 'logistics/SalesInvoice/' + id,
    method: 'get'
  })
}

/**
* 删除销售凭证
* @param {主键} pid
*/
export function delSalesInvoice(pid) {
  return request({
    url: 'logistics/SalesInvoice/delete/' + pid,
    method: 'delete'
  })
}
// 导出销售凭证
export async function exportSalesInvoice(query) {
  await downFile('logistics/SalesInvoice/export', { ...query })
}
