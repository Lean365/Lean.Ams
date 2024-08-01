import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 制二分页查询
 * @param {查询条件} data
 */
export function listPpEcMasterPcba(query) {
  return request({
    url: 'Logistics/PpEcMasterPcba/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增制二
 * @param data
 */
export function addPpEcMasterPcba(data) {
  return request({
    url: 'Logistics/PpEcMasterPcba',
    method: 'post',
    data: data,
  })
}
/**
 * 修改制二
 * @param data
 */
export function updatePpEcMasterPcba(data) {
  return request({
    url: 'Logistics/PpEcMasterPcba',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取制二详情
 * @param {Id}
 */
export function getPpEcMasterPcba(id) {
  return request({
    url: 'Logistics/PpEcMasterPcba/' + id,
    method: 'get'
  })
}

/**
 * 删除制二
 * @param {主键} pid
 */
export function delPpEcMasterPcba(pid) {
  return request({
    url: 'Logistics/PpEcMasterPcba/delete/' + pid,
    method: 'delete'
  })
}
// 导出制二
export async function exportPpEcMasterPcba(query) {
  await downFile('Logistics/PpEcMasterPcba/export', { ...query })
}
