import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 受检分页查询
 * @param {查询条件} data
 */
export function listPpEcMasterIqc(query) {
  return request({
    url: 'Logistics/PpEcMasterIqc/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增受检
 * @param data
 */
export function addPpEcMasterIqc(data) {
  return request({
    url: 'Logistics/PpEcMasterIqc',
    method: 'post',
    data: data,
  })
}
/**
 * 修改受检
 * @param data
 */
export function updatePpEcMasterIqc(data) {
  return request({
    url: 'Logistics/PpEcMasterIqc',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取受检详情
 * @param {Id}
 */
export function getPpEcMasterIqc(id) {
  return request({
    url: 'Logistics/PpEcMasterIqc/' + id,
    method: 'get'
  })
}

/**
 * 删除受检
 * @param {主键} pid
 */
export function delPpEcMasterIqc(pid) {
  return request({
    url: 'Logistics/PpEcMasterIqc/delete/' + pid,
    method: 'delete'
  })
}
// 导出受检
export async function exportPpEcMasterIqc(query) {
  await downFile('Logistics/PpEcMasterIqc/export', { ...query })
}
