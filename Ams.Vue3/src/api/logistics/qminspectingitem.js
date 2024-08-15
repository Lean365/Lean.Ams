import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 检测项目分页查询
 * @param {查询条件} data
 */
export function listQmInspectingItem(query) {
  return request({
    url: 'Logistics/QmInspectingItem/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增检测项目
 * @param data
 */
export function addQmInspectingItem(data) {
  return request({
    url: 'Logistics/QmInspectingItem',
    method: 'post',
    data: data,
  })
}
/**
 * 修改检测项目
 * @param data
 */
export function updateQmInspectingItem(data) {
  return request({
    url: 'Logistics/QmInspectingItem',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取检测项目详情
 * @param {Id}
 */
export function getQmInspectingItem(id) {
  return request({
    url: 'Logistics/QmInspectingItem/' + id,
    method: 'get'
  })
}

/**
 * 删除检测项目
 * @param {主键} pid
 */
export function delQmInspectingItem(pid) {
  return request({
    url: 'Logistics/QmInspectingItem/delete/' + pid,
    method: 'delete'
  })
}
// 导出检测项目
export async function exportQmInspectingItem(query) {
  await downFile('Logistics/QmInspectingItem/export', { ...query })
}
