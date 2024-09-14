import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 设变分页查询
 * @param {查询条件} data
 */
export function listPpEcMaster(query) {
  return request({
    url: 'Logistics/PpEcMaster/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增设变
 * @param data
 */
export function addPpEcMaster(data) {
  return request({
    url: 'Logistics/PpEcMaster',
    method: 'post',
    data: data,
  })
}
/**
 * 修改设变
 * @param data
 */
export function updatePpEcMaster(data) {
  return request({
    url: 'Logistics/PpEcMaster',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取设变详情
 * @param {Id}
 */
export function getPpEcMaster(id) {
  return request({
    url: 'Logistics/PpEcMaster/' + id,
    method: 'get'
  })
}

/**
 * 删除设变
 * @param {主键} pid
 */
export function delPpEcMaster(pid) {
  return request({
    url: 'Logistics/PpEcMaster/delete/' + pid,
    method: 'delete'
  })
}
// 导出设变
export async function exportPpEcMaster(query) {
  await downFile('Logistics/PpEcMaster/export', { ...query })
}
