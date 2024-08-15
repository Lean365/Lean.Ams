import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * Pe设变分页查询
 * @param {查询条件} data
 */
export function listPpEcSlavePe(query) {
  return request({
    url: 'Logistics/PpEcSlavePe/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增Pe设变
 * @param data
 */
export function addPpEcSlavePe(data) {
  return request({
    url: 'Logistics/PpEcSlavePe',
    method: 'post',
    data: data,
  })
}
/**
 * 修改Pe设变
 * @param data
 */
export function updatePpEcSlavePe(data) {
  return request({
    url: 'Logistics/PpEcSlavePe',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取Pe设变详情
 * @param {Id}
 */
export function getPpEcSlavePe(id) {
  return request({
    url: 'Logistics/PpEcSlavePe/' + id,
    method: 'get'
  })
}

/**
 * 删除Pe设变
 * @param {主键} pid
 */
export function delPpEcSlavePe(pid) {
  return request({
    url: 'Logistics/PpEcSlavePe/delete/' + pid,
    method: 'delete'
  })
}
// 导出Pe设变
export async function exportPpEcSlavePe(query) {
  await downFile('Logistics/PpEcSlavePe/export', { ...query })
}
