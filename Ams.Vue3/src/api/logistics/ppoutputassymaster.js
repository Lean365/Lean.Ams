import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 组立OPH分页查询
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
 * 新增组立OPH
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
 * 修改组立OPH
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
 * 获取组立OPH详情
 * @param {Id}
 */
export function getPpOutputAssyMaster(id) {
  return request({
    url: 'Logistics/PpOutputAssyMaster/' + id,
    method: 'get'
  })
}

/**
 * 删除组立OPH
 * @param {主键} pid
 */
export function delPpOutputAssyMaster(pid) {
  return request({
    url: 'Logistics/PpOutputAssyMaster/delete/' + pid,
    method: 'delete'
  })
}
// 导出组立OPH
export async function exportPpOutputAssyMaster(query) {
  await downFile('Logistics/PpOutputAssyMaster/export', { ...query })
}
