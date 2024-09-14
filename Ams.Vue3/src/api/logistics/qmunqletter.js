import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 不合格联络分页查询
 * @param {查询条件} data
 */
export function listQmUnqLetter(query) {
  return request({
    url: 'Logistics/QmUnqLetter/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增不合格联络
 * @param data
 */
export function addQmUnqLetter(data) {
  return request({
    url: 'Logistics/QmUnqLetter',
    method: 'post',
    data: data,
  })
}
/**
 * 修改不合格联络
 * @param data
 */
export function updateQmUnqLetter(data) {
  return request({
    url: 'Logistics/QmUnqLetter',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取不合格联络详情
 * @param {Id}
 */
export function getQmUnqLetter(id) {
  return request({
    url: 'Logistics/QmUnqLetter/' + id,
    method: 'get'
  })
}

/**
 * 删除不合格联络
 * @param {主键} pid
 */
export function delQmUnqLetter(pid) {
  return request({
    url: 'Logistics/QmUnqLetter/delete/' + pid,
    method: 'delete'
  })
}
// 导出不合格联络
export async function exportQmUnqLetter(query) {
  await downFile('Logistics/QmUnqLetter/export', { ...query })
}
