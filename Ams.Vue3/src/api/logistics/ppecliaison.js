import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 技联分页查询
 * @param {查询条件} data
 */
export function listPpEcLiaison(query) {
  return request({
    url: 'Logistics/PpEcLiaison/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增技联
 * @param data
 */
export function addPpEcLiaison(data) {
  return request({
    url: 'Logistics/PpEcLiaison',
    method: 'post',
    data: data,
  })
}
/**
 * 修改技联
 * @param data
 */
export function updatePpEcLiaison(data) {
  return request({
    url: 'Logistics/PpEcLiaison',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取技联详情
 * @param {Id}
 */
export function getPpEcLiaison(id) {
  return request({
    url: 'Logistics/PpEcLiaison/' + id,
    method: 'get'
  })
}

/**
 * 删除技联
 * @param {主键} pid
 */
export function delPpEcLiaison(pid) {
  return request({
    url: 'Logistics/PpEcLiaison/delete/' + pid,
    method: 'delete'
  })
}
// 导出技联
export async function exportPpEcLiaison(query) {
  await downFile('Logistics/PpEcLiaison/export', { ...query })
}
