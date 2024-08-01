import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * Pur设变分页查询
 * @param {查询条件} data
 */
export function listPpEcSlavePur(query) {
  return request({
    url: 'Logistics/PpEcSlavePur/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增Pur设变
 * @param data
 */
export function addPpEcSlavePur(data) {
  return request({
    url: 'Logistics/PpEcSlavePur',
    method: 'post',
    data: data,
  })
}
/**
 * 修改Pur设变
 * @param data
 */
export function updatePpEcSlavePur(data) {
  return request({
    url: 'Logistics/PpEcSlavePur',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取Pur设变详情
 * @param {Id}
 */
export function getPpEcSlavePur(id) {
  return request({
    url: 'Logistics/PpEcSlavePur/' + id,
    method: 'get'
  })
}

/**
 * 删除Pur设变
 * @param {主键} pid
 */
export function delPpEcSlavePur(pid) {
  return request({
    url: 'Logistics/PpEcSlavePur/delete/' + pid,
    method: 'delete'
  })
}
// 导出Pur设变
export async function exportPpEcSlavePur(query) {
  await downFile('Logistics/PpEcSlavePur/export', { ...query })
}
