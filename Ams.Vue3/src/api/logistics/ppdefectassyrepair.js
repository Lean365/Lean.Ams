import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 制一不良分页查询
 * @param {查询条件} data
 */
export function listPpDefectAssyRepair(query) {
  return request({
    url: 'Logistics/PpDefectAssyRepair/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增制一不良
 * @param data
 */
export function addPpDefectAssyRepair(data) {
  return request({
    url: 'Logistics/PpDefectAssyRepair',
    method: 'post',
    data: data,
  })
}
/**
 * 修改制一不良
 * @param data
 */
export function updatePpDefectAssyRepair(data) {
  return request({
    url: 'Logistics/PpDefectAssyRepair',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取制一不良详情
 * @param {Id}
 */
export function getPpDefectAssyRepair(id) {
  return request({
    url: 'Logistics/PpDefectAssyRepair/' + id,
    method: 'get'
  })
}

/**
 * 删除制一不良
 * @param {主键} pid
 */
export function delPpDefectAssyRepair(pid) {
  return request({
    url: 'Logistics/PpDefectAssyRepair/delete/' + pid,
    method: 'delete'
  })
}
// 导出制一不良
export async function exportPpDefectAssyRepair(query) {
  await downFile('Logistics/PpDefectAssyRepair/export', { ...query })
}
