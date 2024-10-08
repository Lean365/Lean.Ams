import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 销售商分页查询
 * @param {查询条件} data
 */
export function listMmVendor(query) {
  return request({
    url: 'Logistics/MmVendor/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增销售商
 * @param data
 */
export function addMmVendor(data) {
  return request({
    url: 'Logistics/MmVendor',
    method: 'post',
    data: data,
  })
}
/**
 * 修改销售商
 * @param data
 */
export function updateMmVendor(data) {
  return request({
    url: 'Logistics/MmVendor',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取销售商详情
 * @param {Id}
 */
export function getMmVendor(id) {
  return request({
    url: 'Logistics/MmVendor/' + id,
    method: 'get'
  })
}

/**
 * 删除销售商
 * @param {主键} pid
 */
export function delMmVendor(pid) {
  return request({
    url: 'Logistics/MmVendor/delete/' + pid,
    method: 'delete'
  })
}
// 导出销售商
export async function exportMmVendor(query) {
  await downFile('Logistics/MmVendor/export', { ...query })
}
