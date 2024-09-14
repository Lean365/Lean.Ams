import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * PCBA明细分页查询
 * @param {查询条件} data
 */
export function listPpOutputPcbaSlv(query) {
  return request({
    url: 'Logistics/PpOutputPcbaSlv/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增PCBA明细
 * @param data
 */
export function addPpOutputPcbaSlv(data) {
  return request({
    url: 'Logistics/PpOutputPcbaSlv',
    method: 'post',
    data: data,
  })
}
/**
 * 修改PCBA明细
 * @param data
 */
export function updatePpOutputPcbaSlv(data) {
  return request({
    url: 'Logistics/PpOutputPcbaSlv',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取PCBA明细详情
 * @param {Id}
 */
export function getPpOutputPcbaSlv(id) {
  return request({
    url: 'Logistics/PpOutputPcbaSlv/' + id,
    method: 'get'
  })
}

/**
 * 删除PCBA明细
 * @param {主键} pid
 */
export function delPpOutputPcbaSlv(pid) {
  return request({
    url: 'Logistics/PpOutputPcbaSlv/delete/' + pid,
    method: 'delete'
  })
}
// 导出PCBA明细
export async function exportPpOutputPcbaSlv(query) {
  await downFile('Logistics/PpOutputPcbaSlv/export', { ...query })
}
