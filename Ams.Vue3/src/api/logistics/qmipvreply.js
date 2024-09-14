import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 分析对策分页查询
 * @param {查询条件} data
 */
export function listQmIpvReply(query) {
  return request({
    url: 'Logistics/QmIpvReply/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增分析对策
 * @param data
 */
export function addQmIpvReply(data) {
  return request({
    url: 'Logistics/QmIpvReply',
    method: 'post',
    data: data,
  })
}
/**
 * 修改分析对策
 * @param data
 */
export function updateQmIpvReply(data) {
  return request({
    url: 'Logistics/QmIpvReply',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取分析对策详情
 * @param {Id}
 */
export function getQmIpvReply(id) {
  return request({
    url: 'Logistics/QmIpvReply/' + id,
    method: 'get'
  })
}

/**
 * 删除分析对策
 * @param {主键} pid
 */
export function delQmIpvReply(pid) {
  return request({
    url: 'Logistics/QmIpvReply/delete/' + pid,
    method: 'delete'
  })
}
// 导出分析对策
export async function exportQmIpvReply(query) {
  await downFile('Logistics/QmIpvReply/export', { ...query })
}
