import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 看板分页查询
 * @param {查询条件} data
 */
export function listRoutineBoard(query) {
  return request({
    url: 'Routine/RoutineBoard/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增看板
 * @param data
 */
export function addRoutineBoard(data) {
  return request({
    url: 'Routine/RoutineBoard',
    method: 'post',
    data: data,
  })
}
/**
 * 修改看板
 * @param data
 */
export function updateRoutineBoard(data) {
  return request({
    url: 'Routine/RoutineBoard',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取看板详情
 * @param {Id}
 */
export function getRoutineBoard(id) {
  return request({
    url: 'Routine/RoutineBoard/' + id,
    method: 'get'
  })
}

/**
 * 删除看板
 * @param {主键} pid
 */
export function delRoutineBoard(pid) {
  return request({
    url: 'Routine/RoutineBoard/delete/' + pid,
    method: 'delete'
  })
}
// 导出看板
export async function exportRoutineBoard(query) {
  await downFile('Routine/RoutineBoard/export', { ...query })
}
