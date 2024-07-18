import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 顾客信息分页查询
 * @param {查询条件} data
 */
export function listSdCustomer(query) {
  return request({
    url: 'Logistics/SdCustomer/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增顾客信息
 * @param data
 */
export function addSdCustomer(data) {
  return request({
    url: 'Logistics/SdCustomer',
    method: 'post',
    data: data,
  })
}
/**
 * 修改顾客信息
 * @param data
 */
export function updateSdCustomer(data) {
  return request({
    url: 'Logistics/SdCustomer',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取顾客信息详情
 * @param {Id}
 */
export function getSdCustomer(id) {
  return request({
    url: 'Logistics/SdCustomer/' + id,
    method: 'get'
  })
}

/**
 * 删除顾客信息
 * @param {主键} pid
 */
export function delSdCustomer(pid) {
  return request({
    url: 'Logistics/SdCustomer/delete/' + pid,
    method: 'delete'
  })
}
// 导出顾客信息
export async function exportSdCustomer(query) {
  await downFile('Logistics/SdCustomer/export', { ...query })
}
