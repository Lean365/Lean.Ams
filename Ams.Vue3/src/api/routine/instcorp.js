import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 公司代码分页查询
 * @param {查询条件} data
 */
export function listInstCorp(query) {
  return request({
    url: 'Routine/InstCorp/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增公司代码
 * @param data
 */
export function addInstCorp(data) {
  return request({
    url: 'Routine/InstCorp',
    method: 'post',
    data: data,
  })
}
/**
 * 修改公司代码
 * @param data
 */
export function updateInstCorp(data) {
  return request({
    url: 'Routine/InstCorp',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取公司代码详情
 * @param {Id}
 */
export function getInstCorp(id) {
  return request({
    url: 'Routine/InstCorp/' + id,
    method: 'get'
  })
}

/**
 * 删除公司代码
 * @param {主键} pid
 */
export function delInstCorp(pid) {
  return request({
    url: 'Routine/InstCorp/delete/' + pid,
    method: 'delete'
  })
}
// 导出公司代码
export async function exportInstCorp(query) {
  await downFile('Routine/InstCorp/export', { ...query })
}
