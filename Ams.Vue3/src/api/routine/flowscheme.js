import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 流程分页查询
 * @param {查询条件} data
 */
export function listFlowScheme(query) {
  return request({
    url: 'Routine/FlowScheme/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增流程
 * @param data
 */
export function addFlowScheme(data) {
  return request({
    url: 'Routine/FlowScheme',
    method: 'post',
    data: data,
  })
}
/**
 * 修改流程
 * @param data
 */
export function updateFlowScheme(data) {
  return request({
    url: 'Routine/FlowScheme',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取流程详情
 * @param {Id}
 */
export function getFlowScheme(id) {
  return request({
    url: 'Routine/FlowScheme/' + id,
    method: 'get'
  })
}

/**
 * 删除流程
 * @param {主键} pid
 */
export function delFlowScheme(pid) {
  return request({
    url: 'Routine/FlowScheme/delete/' + pid,
    method: 'delete'
  })
}
// 导出流程
export async function exportFlowScheme(query) {
  await downFile('Routine/FlowScheme/export', { ...query })
}
