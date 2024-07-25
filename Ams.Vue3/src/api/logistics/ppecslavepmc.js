import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * Pmc设变分页查询
 * @param {查询条件} data
 */
export function listPpEcSlavePmc(query) {
  return request({
    url: 'Logistics/PpEcSlavePmc/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增Pmc设变
 * @param data
 */
export function addPpEcSlavePmc(data) {
  return request({
    url: 'Logistics/PpEcSlavePmc',
    method: 'post',
    data: data,
  })
}
/**
 * 修改Pmc设变
 * @param data
 */
export function updatePpEcSlavePmc(data) {
  return request({
    url: 'Logistics/PpEcSlavePmc',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取Pmc设变详情
 * @param {Id}
 */
export function getPpEcSlavePmc(id) {
  return request({
    url: 'Logistics/PpEcSlavePmc/' + id,
    method: 'get'
  })
}

/**
 * 删除Pmc设变
 * @param {主键} pid
 */
export function delPpEcSlavePmc(pid) {
  return request({
    url: 'Logistics/PpEcSlavePmc/delete/' + pid,
    method: 'delete'
  })
}
// 导出Pmc设变
export async function exportPpEcSlavePmc(query) {
  await downFile('Logistics/PpEcSlavePmc/export', { ...query })
}
