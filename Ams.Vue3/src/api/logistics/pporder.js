import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 生产工单分页查询
 * @param {查询条件} data
 */
export function listPpOrder(query) {
  return request({
    url: 'Logistics/PpOrder/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增生产工单
 * @param data
 */
export function addPpOrder(data) {
  return request({
    url: 'Logistics/PpOrder',
    method: 'post',
    data: data,
  })
}
/**
 * 修改生产工单
 * @param data
 */
export function updatePpOrder(data) {
  return request({
    url: 'Logistics/PpOrder',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取生产工单详情
 * @param {Id}
 */
export function getPpOrder(id) {
  return request({
    url: 'Logistics/PpOrder/' + id,
    method: 'get'
  })
}

/**
 * 删除生产工单
 * @param {主键} pid
 */
export function delPpOrder(pid) {
  return request({
    url: 'Logistics/PpOrder/delete/' + pid,
    method: 'delete'
  })
}
// 导出生产工单
export async function exportPpOrder(query) {
  await downFile('Logistics/PpOrder/export', { ...query })
}
