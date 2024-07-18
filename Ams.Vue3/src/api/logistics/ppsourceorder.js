import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 源订单分页查询
 * @param {查询条件} data
 */
export function listPpSourceOrder(query) {
  return request({
    url: 'Logistics/PpSourceOrder/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增源订单
 * @param data
 */
export function addPpSourceOrder(data) {
  return request({
    url: 'Logistics/PpSourceOrder',
    method: 'post',
    data: data,
  })
}
/**
 * 修改源订单
 * @param data
 */
export function updatePpSourceOrder(data) {
  return request({
    url: 'Logistics/PpSourceOrder',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取源订单详情
 * @param {Id}
 */
export function getPpSourceOrder(id) {
  return request({
    url: 'Logistics/PpSourceOrder/' + id,
    method: 'get'
  })
}

/**
 * 删除源订单
 * @param {主键} pid
 */
export function delPpSourceOrder(pid) {
  return request({
    url: 'Logistics/PpSourceOrder/delete/' + pid,
    method: 'delete'
  })
}
// 导出源订单
export async function exportPpSourceOrder(query) {
  await downFile('Logistics/PpSourceOrder/export', { ...query })
}
