import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * Mm设变分页查询
 * @param {查询条件} data
 */
export function listPpEcSlaveMm(query) {
  return request({
    url: 'Logistics/PpEcSlaveMm/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增Mm设变
 * @param data
 */
export function addPpEcSlaveMm(data) {
  return request({
    url: 'Logistics/PpEcSlaveMm',
    method: 'post',
    data: data,
  })
}
/**
 * 修改Mm设变
 * @param data
 */
export function updatePpEcSlaveMm(data) {
  return request({
    url: 'Logistics/PpEcSlaveMm',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取Mm设变详情
 * @param {Id}
 */
export function getPpEcSlaveMm(id) {
  return request({
    url: 'Logistics/PpEcSlaveMm/' + id,
    method: 'get'
  })
}

/**
 * 删除Mm设变
 * @param {主键} pid
 */
export function delPpEcSlaveMm(pid) {
  return request({
    url: 'Logistics/PpEcSlaveMm/delete/' + pid,
    method: 'delete'
  })
}
// 导出Mm设变
export async function exportPpEcSlaveMm(query) {
  await downFile('Logistics/PpEcSlaveMm/export', { ...query })
}
