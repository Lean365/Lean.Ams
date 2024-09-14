import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * PCBA明细分页查询
 * @param {查询条件} data
 */
export function listPpOutputPcbaSlave(query) {
  return request({
    url: 'Logistics/PpOutputPcbaSlave/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增PCBA明细
 * @param data
 */
export function addPpOutputPcbaSlave(data) {
  return request({
    url: 'Logistics/PpOutputPcbaSlave',
    method: 'post',
    data: data,
  })
}
/**
 * 修改PCBA明细
 * @param data
 */
export function updatePpOutputPcbaSlave(data) {
  return request({
    url: 'Logistics/PpOutputPcbaSlave',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取PCBA明细详情
 * @param {Id}
 */
export function getPpOutputPcbaSlave(id) {
  return request({
    url: 'Logistics/PpOutputPcbaSlave/' + id,
    method: 'get'
  })
}

/**
 * 删除PCBA明细
 * @param {主键} pid
 */
export function delPpOutputPcbaSlave(pid) {
  return request({
    url: 'Logistics/PpOutputPcbaSlave/delete/' + pid,
    method: 'delete'
  })
}
// 导出PCBA明细
export async function exportPpOutputPcbaSlave(query) {
  await downFile('Logistics/PpOutputPcbaSlave/export', { ...query })
}
