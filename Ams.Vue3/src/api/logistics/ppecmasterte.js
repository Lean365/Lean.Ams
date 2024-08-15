import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 技术分页查询
 * @param {查询条件} data
 */
export function listPpEcMasterTe(query) {
  return request({
    url: 'Logistics/PpEcMasterTe/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增技术
 * @param data
 */
export function addPpEcMasterTe(data) {
  return request({
    url: 'Logistics/PpEcMasterTe',
    method: 'post',
    data: data,
  })
}
/**
 * 修改技术
 * @param data
 */
export function updatePpEcMasterTe(data) {
  return request({
    url: 'Logistics/PpEcMasterTe',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取技术详情
 * @param {Id}
 */
export function getPpEcMasterTe(id) {
  return request({
    url: 'Logistics/PpEcMasterTe/' + id,
    method: 'get'
  })
}

/**
 * 删除技术
 * @param {主键} pid
 */
export function delPpEcMasterTe(pid) {
  return request({
    url: 'Logistics/PpEcMasterTe/delete/' + pid,
    method: 'delete'
  })
}
// 导出技术
export async function exportPpEcMasterTe(query) {
  await downFile('Logistics/PpEcMasterTe/export', { ...query })
}
