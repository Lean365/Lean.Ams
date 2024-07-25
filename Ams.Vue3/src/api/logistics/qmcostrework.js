import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 返工改修分页查询
 * @param {查询条件} data
 */
export function listQmCostRework(query) {
  return request({
    url: 'Logistics/QmCostRework/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增返工改修
 * @param data
 */
export function addQmCostRework(data) {
  return request({
    url: 'Logistics/QmCostRework',
    method: 'post',
    data: data,
  })
}
/**
 * 修改返工改修
 * @param data
 */
export function updateQmCostRework(data) {
  return request({
    url: 'Logistics/QmCostRework',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取返工改修详情
 * @param {Id}
 */
export function getQmCostRework(id) {
  return request({
    url: 'Logistics/QmCostRework/' + id,
    method: 'get'
  })
}

/**
 * 删除返工改修
 * @param {主键} pid
 */
export function delQmCostRework(pid) {
  return request({
    url: 'Logistics/QmCostRework/delete/' + pid,
    method: 'delete'
  })
}
// 导出返工改修
export async function exportQmCostRework(query) {
  await downFile('Logistics/QmCostRework/export', { ...query })
}
