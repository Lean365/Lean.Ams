import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 检测项目分页查询
 * @param {查询条件} data
 */
export function listQmInspItem(query) {
  return request({
    url: 'Logistics/QmInspItem/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增检测项目
 * @param data
 */
export function addQmInspItem(data) {
  return request({
    url: 'Logistics/QmInspItem',
    method: 'post',
    data: data,
  })
}
/**
 * 修改检测项目
 * @param data
 */
export function updateQmInspItem(data) {
  return request({
    url: 'Logistics/QmInspItem',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取检测项目详情
 * @param {Id}
 */
export function getQmInspItem(id) {
  return request({
    url: 'Logistics/QmInspItem/' + id,
    method: 'get'
  })
}

/**
 * 删除检测项目
 * @param {主键} pid
 */
export function delQmInspItem(pid) {
  return request({
    url: 'Logistics/QmInspItem/delete/' + pid,
    method: 'delete'
  })
}
// 导出检测项目
export async function exportQmInspItem(query) {
  await downFile('Logistics/QmInspItem/export', { ...query })
}
