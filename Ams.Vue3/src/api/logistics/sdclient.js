import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 客户分页查询
 * @param {查询条件} data
 */
export function listSdClient(query) {
  return request({
    url: 'Logistics/SdClient/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增客户
 * @param data
 */
export function addSdClient(data) {
  return request({
    url: 'Logistics/SdClient',
    method: 'post',
    data: data,
  })
}
/**
 * 修改客户
 * @param data
 */
export function updateSdClient(data) {
  return request({
    url: 'Logistics/SdClient',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取客户详情
 * @param {Id}
 */
export function getSdClient(id) {
  return request({
    url: 'Logistics/SdClient/' + id,
    method: 'get'
  })
}

/**
 * 删除客户
 * @param {主键} pid
 */
export function delSdClient(pid) {
  return request({
    url: 'Logistics/SdClient/delete/' + pid,
    method: 'delete'
  })
}
// 导出客户
export async function exportSdClient(query) {
  await downFile('Logistics/SdClient/export', { ...query })
}
