import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 销售价格分页查询
 * @param {查询条件} data
 */
export function listSdSellingPrice(query) {
  return request({
    url: 'Logistics/SdSellingPrice/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增销售价格
 * @param data
 */
export function addSdSellingPrice(data) {
  return request({
    url: 'Logistics/SdSellingPrice',
    method: 'post',
    data: data,
  })
}
/**
 * 修改销售价格
 * @param data
 */
export function updateSdSellingPrice(data) {
  return request({
    url: 'Logistics/SdSellingPrice',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取销售价格详情
 * @param {Id}
 */
export function getSdSellingPrice(id) {
  return request({
    url: 'Logistics/SdSellingPrice/' + id,
    method: 'get'
  })
}

/**
 * 删除销售价格
 * @param {主键} pid
 */
export function delSdSellingPrice(pid) {
  return request({
    url: 'Logistics/SdSellingPrice/delete/' + pid,
    method: 'delete'
  })
}
// 导出销售价格
export async function exportSdSellingPrice(query) {
  await downFile('Logistics/SdSellingPrice/export', { ...query })
}
