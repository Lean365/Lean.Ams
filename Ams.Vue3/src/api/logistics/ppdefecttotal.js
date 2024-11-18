import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 不良统计分页查询
 * @param {查询条件} data
 */
export function listPpDefectTotal(query) {
  return request({
    url: 'Logistics/PpDefectTotal/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增不良统计
 * @param data
 */
export function addPpDefectTotal(data) {
  return request({
    url: 'Logistics/PpDefectTotal',
    method: 'post',
    data: data,
  })
}
/**
 * 修改不良统计
 * @param data
 */
export function updatePpDefectTotal(data) {
  return request({
    url: 'Logistics/PpDefectTotal',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取不良统计详情
 * @param {Id}
 */
export function getPpDefectTotal(id) {
  return request({
    url: 'Logistics/PpDefectTotal/' + id,
    method: 'get'
  })
}

/**
 * 删除不良统计
 * @param {主键} pid
 */
export function delPpDefectTotal(pid) {
  return request({
    url: 'Logistics/PpDefectTotal/delete/' + pid,
    method: 'delete'
  })
}
// 导出不良统计
export async function exportPpDefectTotal(query) {
  await downFile('Logistics/PpDefectTotal/export', { ...query })
}
