import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * PP客诉分页查询
 * @param {查询条件} data
 */
export function listQmComplaintsPp(query) {
  return request({
    url: 'Logistics/QmComplaintsPp/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增PP客诉
 * @param data
 */
export function addQmComplaintsPp(data) {
  return request({
    url: 'Logistics/QmComplaintsPp',
    method: 'post',
    data: data,
  })
}
/**
 * 修改PP客诉
 * @param data
 */
export function updateQmComplaintsPp(data) {
  return request({
    url: 'Logistics/QmComplaintsPp',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取PP客诉详情
 * @param {Id}
 */
export function getQmComplaintsPp(id) {
  return request({
    url: 'Logistics/QmComplaintsPp/' + id,
    method: 'get'
  })
}

/**
 * 删除PP客诉
 * @param {主键} pid
 */
export function delQmComplaintsPp(pid) {
  return request({
    url: 'Logistics/QmComplaintsPp/delete/' + pid,
    method: 'delete'
  })
}
// 导出PP客诉
export async function exportQmComplaintsPp(query) {
  await downFile('Logistics/QmComplaintsPp/export', { ...query })
}
