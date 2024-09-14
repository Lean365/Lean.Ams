import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * QC客诉分页查询
 * @param {查询条件} data
 */
export function listQmComplaintsQc(query) {
  return request({
    url: 'Logistics/QmComplaintsQc/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增QC客诉
 * @param data
 */
export function addQmComplaintsQc(data) {
  return request({
    url: 'Logistics/QmComplaintsQc',
    method: 'post',
    data: data,
  })
}
/**
 * 修改QC客诉
 * @param data
 */
export function updateQmComplaintsQc(data) {
  return request({
    url: 'Logistics/QmComplaintsQc',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取QC客诉详情
 * @param {Id}
 */
export function getQmComplaintsQc(id) {
  return request({
    url: 'Logistics/QmComplaintsQc/' + id,
    method: 'get'
  })
}

/**
 * 删除QC客诉
 * @param {主键} pid
 */
export function delQmComplaintsQc(pid) {
  return request({
    url: 'Logistics/QmComplaintsQc/delete/' + pid,
    method: 'delete'
  })
}
// 导出QC客诉
export async function exportQmComplaintsQc(query) {
  await downFile('Logistics/QmComplaintsQc/export', { ...query })
}
