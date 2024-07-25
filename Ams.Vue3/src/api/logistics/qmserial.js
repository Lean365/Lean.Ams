import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 序列号扫描分页查询
 * @param {查询条件} data
 */
export function listQmSerial(query) {
  return request({
    url: 'Logistics/QmSerial/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增序列号扫描
 * @param data
 */
export function addQmSerial(data) {
  return request({
    url: 'Logistics/QmSerial',
    method: 'post',
    data: data,
  })
}
/**
 * 修改序列号扫描
 * @param data
 */
export function updateQmSerial(data) {
  return request({
    url: 'Logistics/QmSerial',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取序列号扫描详情
 * @param {Id}
 */
export function getQmSerial(id) {
  return request({
    url: 'Logistics/QmSerial/' + id,
    method: 'get'
  })
}

/**
 * 删除序列号扫描
 * @param {主键} pid
 */
export function delQmSerial(pid) {
  return request({
    url: 'Logistics/QmSerial/delete/' + pid,
    method: 'delete'
  })
}
// 导出序列号扫描
export async function exportQmSerial(query) {
  await downFile('Logistics/QmSerial/export', { ...query })
}
