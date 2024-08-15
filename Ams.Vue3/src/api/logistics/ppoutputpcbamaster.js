import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 制二OPH主表分页查询
 * @param {查询条件} data
 */
export function listPpOutputPcbaMaster(query) {
  return request({
    url: 'Logistics/PpOutputPcbaMaster/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增制二OPH主表
 * @param data
 */
export function addPpOutputPcbaMaster(data) {
  return request({
    url: 'Logistics/PpOutputPcbaMaster',
    method: 'post',
    data: data,
  })
}
/**
 * 修改制二OPH主表
 * @param data
 */
export function updatePpOutputPcbaMaster(data) {
  return request({
    url: 'Logistics/PpOutputPcbaMaster',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取制二OPH主表详情
 * @param {Id}
 */
export function getPpOutputPcbaMaster(id) {
  return request({
    url: 'Logistics/PpOutputPcbaMaster/' + id,
    method: 'get'
  })
}

/**
 * 删除制二OPH主表
 * @param {主键} pid
 */
export function delPpOutputPcbaMaster(pid) {
  return request({
    url: 'Logistics/PpOutputPcbaMaster/delete/' + pid,
    method: 'delete'
  })
}
// 导出制二OPH主表
export async function exportPpOutputPcbaMaster(query) {
  await downFile('Logistics/PpOutputPcbaMaster/export', { ...query })
}
