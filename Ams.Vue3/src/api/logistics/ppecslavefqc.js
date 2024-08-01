import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 品管分页查询
 * @param {查询条件} data
 */
export function listPpEcSlaveFqc(query) {
  return request({
    url: 'Logistics/PpEcSlaveFqc/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增品管
 * @param data
 */
export function addPpEcSlaveFqc(data) {
  return request({
    url: 'Logistics/PpEcSlaveFqc',
    method: 'post',
    data: data,
  })
}
/**
 * 修改品管
 * @param data
 */
export function updatePpEcSlaveFqc(data) {
  return request({
    url: 'Logistics/PpEcSlaveFqc',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取品管详情
 * @param {Id}
 */
export function getPpEcSlaveFqc(id) {
  return request({
    url: 'Logistics/PpEcSlaveFqc/' + id,
    method: 'get'
  })
}

/**
 * 删除品管
 * @param {主键} pid
 */
export function delPpEcSlaveFqc(pid) {
  return request({
    url: 'Logistics/PpEcSlaveFqc/delete/' + pid,
    method: 'delete'
  })
}
// 导出品管
export async function exportPpEcSlaveFqc(query) {
  await downFile('Logistics/PpEcSlaveFqc/export', { ...query })
}
