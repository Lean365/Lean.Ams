import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 供应商信息分页查询
 * @param {查询条件} data
 */
export function listMmSupplier(query) {
  return request({
    url: 'Logistics/MmSupplier/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增供应商信息
 * @param data
 */
export function addMmSupplier(data) {
  return request({
    url: 'Logistics/MmSupplier',
    method: 'post',
    data: data,
  })
}
/**
 * 修改供应商信息
 * @param data
 */
export function updateMmSupplier(data) {
  return request({
    url: 'Logistics/MmSupplier',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取供应商信息详情
 * @param {Id}
 */
export function getMmSupplier(id) {
  return request({
    url: 'Logistics/MmSupplier/' + id,
    method: 'get'
  })
}

/**
 * 删除供应商信息
 * @param {主键} pid
 */
export function delMmSupplier(pid) {
  return request({
    url: 'Logistics/MmSupplier/delete/' + pid,
    method: 'delete'
  })
}
// 导出供应商信息
export async function exportMmSupplier(query) {
  await downFile('Logistics/MmSupplier/export', { ...query })
}
