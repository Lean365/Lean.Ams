import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 源订单序列号分页查询
 * @param {查询条件} data
 */
export function listPpSourceOrderSerial(query) {
  return request({
    url: 'Logistics/PpSourceOrderSerial/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增源订单序列号
 * @param data
 */
export function addPpSourceOrderSerial(data) {
  return request({
    url: 'Logistics/PpSourceOrderSerial',
    method: 'post',
    data: data,
  })
}
/**
 * 修改源订单序列号
 * @param data
 */
export function updatePpSourceOrderSerial(data) {
  return request({
    url: 'Logistics/PpSourceOrderSerial',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取源订单序列号详情
 * @param {Id}
 */
export function getPpSourceOrderSerial(id) {
  return request({
    url: 'Logistics/PpSourceOrderSerial/' + id,
    method: 'get'
  })
}

/**
 * 删除源订单序列号
 * @param {主键} pid
 */
export function delPpSourceOrderSerial(pid) {
  return request({
    url: 'Logistics/PpSourceOrderSerial/delete/' + pid,
    method: 'delete'
  })
}
// 导出源订单序列号
export async function exportPpSourceOrderSerial(query) {
  await downFile('Logistics/PpSourceOrderSerial/export', { ...query })
}
