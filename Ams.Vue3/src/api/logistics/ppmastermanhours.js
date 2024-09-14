import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 标准工时分页查询
 * @param {查询条件} data
 */
export function listPpMasterManhours(query) {
  return request({
    url: 'Logistics/PpMasterManhours/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增标准工时
 * @param data
 */
export function addPpMasterManhours(data) {
  return request({
    url: 'Logistics/PpMasterManhours',
    method: 'post',
    data: data,
  })
}
/**
 * 修改标准工时
 * @param data
 */
export function updatePpMasterManhours(data) {
  return request({
    url: 'Logistics/PpMasterManhours',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取标准工时详情
 * @param {Id}
 */
export function getPpMasterManhours(id) {
  return request({
    url: 'Logistics/PpMasterManhours/' + id,
    method: 'get'
  })
}

/**
 * 删除标准工时
 * @param {主键} pid
 */
export function delPpMasterManhours(pid) {
  return request({
    url: 'Logistics/PpMasterManhours/delete/' + pid,
    method: 'delete'
  })
}
// 导出标准工时
export async function exportPpMasterManhours(query) {
  await downFile('Logistics/PpMasterManhours/export', { ...query })
}
