import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 生管分页查询
 * @param {查询条件} data
 */
export function listEcMasterPmc(query) {
  return request({
    url: 'Logistics/EcMasterPmc/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增生管
 * @param data
 */
export function addEcMasterPmc(data) {
  return request({
    url: 'Logistics/EcMasterPmc',
    method: 'post',
    data: data,
  })
}
/**
 * 修改生管
 * @param data
 */
export function updateEcMasterPmc(data) {
  return request({
    url: 'Logistics/EcMasterPmc',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取生管详情
 * @param {Id}
 */
export function getEcMasterPmc(id) {
  return request({
    url: 'Logistics/EcMasterPmc/' + id,
    method: 'get'
  })
}

/**
 * 删除生管
 * @param {主键} pid
 */
export function delEcMasterPmc(pid) {
  return request({
    url: 'Logistics/EcMasterPmc/delete/' + pid,
    method: 'delete'
  })
}
// 导出生管
export async function exportEcMasterPmc(query) {
  await downFile('Logistics/EcMasterPmc/export', { ...query })
}
