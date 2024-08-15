import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 生管分页查询
 * @param {查询条件} data
 */
export function listPpEcMasterPmc(query) {
  return request({
    url: 'Logistics/PpEcMasterPmc/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增生管
 * @param data
 */
export function addPpEcMasterPmc(data) {
  return request({
    url: 'Logistics/PpEcMasterPmc',
    method: 'post',
    data: data,
  })
}
/**
 * 修改生管
 * @param data
 */
export function updatePpEcMasterPmc(data) {
  return request({
    url: 'Logistics/PpEcMasterPmc',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取生管详情
 * @param {Id}
 */
export function getPpEcMasterPmc(id) {
  return request({
    url: 'Logistics/PpEcMasterPmc/' + id,
    method: 'get'
  })
}

/**
 * 删除生管
 * @param {主键} pid
 */
export function delPpEcMasterPmc(pid) {
  return request({
    url: 'Logistics/PpEcMasterPmc/delete/' + pid,
    method: 'delete'
  })
}
// 导出生管
export async function exportPpEcMasterPmc(query) {
  await downFile('Logistics/PpEcMasterPmc/export', { ...query })
}
