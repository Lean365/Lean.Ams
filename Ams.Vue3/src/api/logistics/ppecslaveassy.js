import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 组立分页查询
 * @param {查询条件} data
 */
export function listPpEcSlaveAssy(query) {
  return request({
    url: 'Logistics/PpEcSlaveAssy/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增组立
 * @param data
 */
export function addPpEcSlaveAssy(data) {
  return request({
    url: 'Logistics/PpEcSlaveAssy',
    method: 'post',
    data: data,
  })
}
/**
 * 修改组立
 * @param data
 */
export function updatePpEcSlaveAssy(data) {
  return request({
    url: 'Logistics/PpEcSlaveAssy',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取组立详情
 * @param {Id}
 */
export function getPpEcSlaveAssy(id) {
  return request({
    url: 'Logistics/PpEcSlaveAssy/' + id,
    method: 'get'
  })
}

/**
 * 删除组立
 * @param {主键} pid
 */
export function delPpEcSlaveAssy(pid) {
  return request({
    url: 'Logistics/PpEcSlaveAssy/delete/' + pid,
    method: 'delete'
  })
}
// 导出组立
export async function exportPpEcSlaveAssy(query) {
  await downFile('Logistics/PpEcSlaveAssy/export', { ...query })
}
