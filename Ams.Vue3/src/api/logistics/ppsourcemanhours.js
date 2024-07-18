import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 源工时分页查询
 * @param {查询条件} data
 */
export function listPpSourceManhours(query) {
  return request({
    url: 'Logistics/PpSourceManhours/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增源工时
 * @param data
 */
export function addPpSourceManhours(data) {
  return request({
    url: 'Logistics/PpSourceManhours',
    method: 'post',
    data: data,
  })
}
/**
 * 修改源工时
 * @param data
 */
export function updatePpSourceManhours(data) {
  return request({
    url: 'Logistics/PpSourceManhours',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取源工时详情
 * @param {Id}
 */
export function getPpSourceManhours(id) {
  return request({
    url: 'Logistics/PpSourceManhours/' + id,
    method: 'get'
  })
}

/**
 * 删除源工时
 * @param {主键} pid
 */
export function delPpSourceManhours(pid) {
  return request({
    url: 'Logistics/PpSourceManhours/delete/' + pid,
    method: 'delete'
  })
}
// 导出源工时
export async function exportPpSourceManhours(query) {
  await downFile('Logistics/PpSourceManhours/export', { ...query })
}
