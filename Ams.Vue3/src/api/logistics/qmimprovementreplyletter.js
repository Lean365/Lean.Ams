import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 分析对策分页查询
 * @param {查询条件} data
 */
export function listQmImprovementReplyletter(query) {
  return request({
    url: 'Logistics/QmImprovementReplyletter/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增分析对策
 * @param data
 */
export function addQmImprovementReplyletter(data) {
  return request({
    url: 'Logistics/QmImprovementReplyletter',
    method: 'post',
    data: data,
  })
}
/**
 * 修改分析对策
 * @param data
 */
export function updateQmImprovementReplyletter(data) {
  return request({
    url: 'Logistics/QmImprovementReplyletter',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取分析对策详情
 * @param {Id}
 */
export function getQmImprovementReplyletter(id) {
  return request({
    url: 'Logistics/QmImprovementReplyletter/' + id,
    method: 'get'
  })
}

/**
 * 删除分析对策
 * @param {主键} pid
 */
export function delQmImprovementReplyletter(pid) {
  return request({
    url: 'Logistics/QmImprovementReplyletter/delete/' + pid,
    method: 'delete'
  })
}
// 导出分析对策
export async function exportQmImprovementReplyletter(query) {
  await downFile('Logistics/QmImprovementReplyletter/export', { ...query })
}
