import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 机构目标分页查询
 * @param {查询条件} data
 */
export function listInstPerformance(query) {
  return request({
    url: 'Routine/InstPerformance/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增机构目标
 * @param data
 */
export function addInstPerformance(data) {
  return request({
    url: 'Routine/InstPerformance',
    method: 'post',
    data: data,
  })
}
/**
 * 修改机构目标
 * @param data
 */
export function updateInstPerformance(data) {
  return request({
    url: 'Routine/InstPerformance',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取机构目标详情
 * @param {Id}
 */
export function getInstPerformance(id) {
  return request({
    url: 'Routine/InstPerformance/' + id,
    method: 'get'
  })
}

/**
 * 删除机构目标
 * @param {主键} pid
 */
export function delInstPerformance(pid) {
  return request({
    url: 'Routine/InstPerformance/delete/' + pid,
    method: 'delete'
  })
}
// 导出机构目标
export async function exportInstPerformance(query) {
  await downFile('Routine/InstPerformance/export', { ...query })
}
