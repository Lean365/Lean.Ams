import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 不良明细分页查询
 * @param {查询条件} data
 */
export function listPpDefectAssySlv(query) {
  return request({
    url: 'Logistics/PpDefectAssySlv/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增不良明细
 * @param data
 */
export function addPpDefectAssySlv(data) {
  return request({
    url: 'Logistics/PpDefectAssySlv',
    method: 'post',
    data: data,
  })
}
/**
 * 修改不良明细
 * @param data
 */
export function updatePpDefectAssySlv(data) {
  return request({
    url: 'Logistics/PpDefectAssySlv',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取不良明细详情
 * @param {Id}
 */
export function getPpDefectAssySlv(id) {
  return request({
    url: 'Logistics/PpDefectAssySlv/' + id,
    method: 'get'
  })
}

/**
 * 删除不良明细
 * @param {主键} pid
 */
export function delPpDefectAssySlv(pid) {
  return request({
    url: 'Logistics/PpDefectAssySlv/delete/' + pid,
    method: 'delete'
  })
}
// 导出不良明细
export async function exportPpDefectAssySlv(query) {
  await downFile('Logistics/PpDefectAssySlv/export', { ...query })
}
