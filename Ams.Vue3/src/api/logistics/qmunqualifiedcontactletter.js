import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 不合格联络分页查询
 * @param {查询条件} data
 */
export function listQmUnqualifiedContactletter(query) {
  return request({
    url: 'Logistics/QmUnqualifiedContactletter/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增不合格联络
 * @param data
 */
export function addQmUnqualifiedContactletter(data) {
  return request({
    url: 'Logistics/QmUnqualifiedContactletter',
    method: 'post',
    data: data,
  })
}
/**
 * 修改不合格联络
 * @param data
 */
export function updateQmUnqualifiedContactletter(data) {
  return request({
    url: 'Logistics/QmUnqualifiedContactletter',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取不合格联络详情
 * @param {Id}
 */
export function getQmUnqualifiedContactletter(id) {
  return request({
    url: 'Logistics/QmUnqualifiedContactletter/' + id,
    method: 'get'
  })
}

/**
 * 删除不合格联络
 * @param {主键} pid
 */
export function delQmUnqualifiedContactletter(pid) {
  return request({
    url: 'Logistics/QmUnqualifiedContactletter/delete/' + pid,
    method: 'delete'
  })
}
// 导出不合格联络
export async function exportQmUnqualifiedContactletter(query) {
  await downFile('Logistics/QmUnqualifiedContactletter/export', { ...query })
}
