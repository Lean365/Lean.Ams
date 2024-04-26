import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 厂商信息分页查询
* @param {查询条件} data
*/
export function listVendor(query) {
  return request({
    url: 'logistics/Vendor/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增厂商信息
* @param data
*/
export function addVendor(data) {
  return request({
    url: 'logistics/Vendor',
    method: 'post',
    data: data,
  })
}
/**
* 修改厂商信息
* @param data
*/
export function updateVendor(data) {
  return request({
    url: 'logistics/Vendor',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取厂商信息详情
* @param {Id}
*/
export function getVendor(id) {
  return request({
    url: 'logistics/Vendor/' + id,
    method: 'get'
  })
}

/**
* 删除厂商信息
* @param {主键} pid
*/
export function delVendor(pid) {
  return request({
    url: 'logistics/Vendor/delete/' + pid,
    method: 'delete'
  })
}
// 导出厂商信息
export async function exportVendor(query) {
  await downFile('logistics/Vendor/export', { ...query })
}
