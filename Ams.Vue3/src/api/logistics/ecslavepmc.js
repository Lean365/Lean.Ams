import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * Pmc设变分页查询
 * @param {查询条件} data
 */
export function listEcSlavePmc(query) {
  return request({
    url: 'Logistics/EcSlavePmc/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增Pmc设变
 * @param data
 */
export function addEcSlavePmc(data) {
  return request({
    url: 'Logistics/EcSlavePmc',
    method: 'post',
    data: data,
  })
}
/**
 * 修改Pmc设变
 * @param data
 */
export function updateEcSlavePmc(data) {
  return request({
    url: 'Logistics/EcSlavePmc',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取Pmc设变详情
 * @param {Id}
 */
export function getEcSlavePmc(id) {
  return request({
    url: 'Logistics/EcSlavePmc/' + id,
    method: 'get'
  })
}

/**
 * 删除Pmc设变
 * @param {主键} pid
 */
export function delEcSlavePmc(pid) {
  return request({
    url: 'Logistics/EcSlavePmc/delete/' + pid,
    method: 'delete'
  })
}
// 导出Pmc设变
export async function exportEcSlavePmc(query) {
  await downFile('Logistics/EcSlavePmc/export', { ...query })
}
