import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * Iqc设变分页查询
 * @param {查询条件} data
 */
export function listPpEcSlaveIqc(query) {
  return request({
    url: 'Logistics/PpEcSlaveIqc/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增Iqc设变
 * @param data
 */
export function addPpEcSlaveIqc(data) {
  return request({
    url: 'Logistics/PpEcSlaveIqc',
    method: 'post',
    data: data,
  })
}
/**
 * 修改Iqc设变
 * @param data
 */
export function updatePpEcSlaveIqc(data) {
  return request({
    url: 'Logistics/PpEcSlaveIqc',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取Iqc设变详情
 * @param {Id}
 */
export function getPpEcSlaveIqc(id) {
  return request({
    url: 'Logistics/PpEcSlaveIqc/' + id,
    method: 'get'
  })
}

/**
 * 删除Iqc设变
 * @param {主键} pid
 */
export function delPpEcSlaveIqc(pid) {
  return request({
    url: 'Logistics/PpEcSlaveIqc/delete/' + pid,
    method: 'delete'
  })
}
// 导出Iqc设变
export async function exportPpEcSlaveIqc(query) {
  await downFile('Logistics/PpEcSlaveIqc/export', { ...query })
}
