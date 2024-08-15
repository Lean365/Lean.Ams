import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 品管分页查询
 * @param {查询条件} data
 */
export function listPpEcMasterFqc(query) {
  return request({
    url: 'Logistics/PpEcMasterFqc/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增品管
 * @param data
 */
export function addPpEcMasterFqc(data) {
  return request({
    url: 'Logistics/PpEcMasterFqc',
    method: 'post',
    data: data,
  })
}
/**
 * 修改品管
 * @param data
 */
export function updatePpEcMasterFqc(data) {
  return request({
    url: 'Logistics/PpEcMasterFqc',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取品管详情
 * @param {Id}
 */
export function getPpEcMasterFqc(id) {
  return request({
    url: 'Logistics/PpEcMasterFqc/' + id,
    method: 'get'
  })
}

/**
 * 删除品管
 * @param {主键} pid
 */
export function delPpEcMasterFqc(pid) {
  return request({
    url: 'Logistics/PpEcMasterFqc/delete/' + pid,
    method: 'delete'
  })
}
// 导出品管
export async function exportPpEcMasterFqc(query) {
  await downFile('Logistics/PpEcMasterFqc/export', { ...query })
}
