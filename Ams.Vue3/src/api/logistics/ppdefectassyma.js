import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 不良分页查询
 * @param {查询条件} data
 */
export function listPpDefectAssyMa(query) {
  return request({
    url: 'Logistics/PpDefectAssyMa/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增不良
 * @param data
 */
export function addPpDefectAssyMa(data) {
  return request({
    url: 'Logistics/PpDefectAssyMa',
    method: 'post',
    data: data,
  })
}
/**
 * 修改不良
 * @param data
 */
export function updatePpDefectAssyMa(data) {
  return request({
    url: 'Logistics/PpDefectAssyMa',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取不良详情
 * @param {Id}
 */
export function getPpDefectAssyMa(id) {
  return request({
    url: 'Logistics/PpDefectAssyMa/' + id,
    method: 'get'
  })
}

/**
 * 删除不良
 * @param {主键} pid
 */
export function delPpDefectAssyMa(pid) {
  return request({
    url: 'Logistics/PpDefectAssyMa/delete/' + pid,
    method: 'delete'
  })
}
// 导出不良
export async function exportPpDefectAssyMa(query) {
  await downFile('Logistics/PpDefectAssyMa/export', { ...query })
}
