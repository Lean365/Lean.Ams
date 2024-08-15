import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * Te设变分页查询
 * @param {查询条件} data
 */
export function listPpEcSlaveTe(query) {
  return request({
    url: 'Logistics/PpEcSlaveTe/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增Te设变
 * @param data
 */
export function addPpEcSlaveTe(data) {
  return request({
    url: 'Logistics/PpEcSlaveTe',
    method: 'post',
    data: data,
  })
}
/**
 * 修改Te设变
 * @param data
 */
export function updatePpEcSlaveTe(data) {
  return request({
    url: 'Logistics/PpEcSlaveTe',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取Te设变详情
 * @param {Id}
 */
export function getPpEcSlaveTe(id) {
  return request({
    url: 'Logistics/PpEcSlaveTe/' + id,
    method: 'get'
  })
}

/**
 * 删除Te设变
 * @param {主键} pid
 */
export function delPpEcSlaveTe(pid) {
  return request({
    url: 'Logistics/PpEcSlaveTe/delete/' + pid,
    method: 'delete'
  })
}
// 导出Te设变
export async function exportPpEcSlaveTe(query) {
  await downFile('Logistics/PpEcSlaveTe/export', { ...query })
}
