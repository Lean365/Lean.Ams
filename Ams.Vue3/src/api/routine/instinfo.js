import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 机构信息分页查询
 * @param {查询条件} data
 */
export function listInstInfo(query) {
  return request({
    url: 'Routine/InstInfo/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增机构信息
 * @param data
 */
export function addInstInfo(data) {
  return request({
    url: 'Routine/InstInfo',
    method: 'post',
    data: data,
  })
}
/**
 * 修改机构信息
 * @param data
 */
export function updateInstInfo(data) {
  return request({
    url: 'Routine/InstInfo',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取机构信息详情
 * @param {Id}
 */
export function getInstInfo(id) {
  return request({
    url: 'Routine/InstInfo/' + id,
    method: 'get'
  })
}

/**
 * 删除机构信息
 * @param {主键} pid
 */
export function delInstInfo(pid) {
  return request({
    url: 'Routine/InstInfo/delete/' + pid,
    method: 'delete'
  })
}
// 导出机构信息
export async function exportInstInfo(query) {
  await downFile('Routine/InstInfo/export', { ...query })
}
