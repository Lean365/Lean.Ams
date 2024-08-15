import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 制一OPH主表分页查询
 * @param {查询条件} data
 */
export function listPpOutputAssyMaster(query) {
  return request({
    url: 'Logistics/PpOutputAssyMaster/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增制一OPH主表
 * @param data
 */
export function addPpOutputAssyMaster(data) {
  return request({
    url: 'Logistics/PpOutputAssyMaster',
    method: 'post',
    data: data,
  })
}
/**
 * 修改制一OPH主表
 * @param data
 */
export function updatePpOutputAssyMaster(data) {
  return request({
    url: 'Logistics/PpOutputAssyMaster',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取制一OPH主表详情
 * @param {Id}
 */
export function getPpOutputAssyMaster(id) {
  return request({
    url: 'Logistics/PpOutputAssyMaster/' + id,
    method: 'get'
  })
}

/**
 * 删除制一OPH主表
 * @param {主键} pid
 */
export function delPpOutputAssyMaster(pid) {
  return request({
    url: 'Logistics/PpOutputAssyMaster/delete/' + pid,
    method: 'delete'
  })
}
// 导出制一OPH主表
export async function exportPpOutputAssyMaster(query) {
  await downFile('Logistics/PpOutputAssyMaster/export', { ...query })
}
