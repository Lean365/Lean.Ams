import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 绩效分页查询
 * @param {查询条件} data
 */
export function listRoutineEhrPerformance(query) {
  return request({
    url: 'Routine/RoutineEhrPerformance/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增绩效
 * @param data
 */
export function addRoutineEhrPerformance(data) {
  return request({
    url: 'Routine/RoutineEhrPerformance',
    method: 'post',
    data: data,
  })
}
/**
 * 修改绩效
 * @param data
 */
export function updateRoutineEhrPerformance(data) {
  return request({
    url: 'Routine/RoutineEhrPerformance',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取绩效详情
 * @param {Id}
 */
export function getRoutineEhrPerformance(id) {
  return request({
    url: 'Routine/RoutineEhrPerformance/' + id,
    method: 'get'
  })
}

/**
 * 删除绩效
 * @param {主键} pid
 */
export function delRoutineEhrPerformance(pid) {
  return request({
    url: 'Routine/RoutineEhrPerformance/delete/' + pid,
    method: 'delete'
  })
}
// 导出绩效
export async function exportRoutineEhrPerformance(query) {
  await downFile('Routine/RoutineEhrPerformance/export', { ...query })
}
