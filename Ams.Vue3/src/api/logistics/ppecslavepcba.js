import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * Pcba设变分页查询
 * @param {查询条件} data
 */
export function listPpEcSlavePcba(query) {
  return request({
    url: 'Logistics/PpEcSlavePcba/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增Pcba设变
 * @param data
 */
export function addPpEcSlavePcba(data) {
  return request({
    url: 'Logistics/PpEcSlavePcba',
    method: 'post',
    data: data,
  })
}
/**
 * 修改Pcba设变
 * @param data
 */
export function updatePpEcSlavePcba(data) {
  return request({
    url: 'Logistics/PpEcSlavePcba',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取Pcba设变详情
 * @param {Id}
 */
export function getPpEcSlavePcba(id) {
  return request({
    url: 'Logistics/PpEcSlavePcba/' + id,
    method: 'get'
  })
}

/**
 * 删除Pcba设变
 * @param {主键} pid
 */
export function delPpEcSlavePcba(pid) {
  return request({
    url: 'Logistics/PpEcSlavePcba/delete/' + pid,
    method: 'delete'
  })
}
// 导出Pcba设变
export async function exportPpEcSlavePcba(query) {
  await downFile('Logistics/PpEcSlavePcba/export', { ...query })
}
