import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 绩效分页查询
 * @param {查询条件} data
 */
export function listRoutineEhrPerformanceSlv(query) {
  return request({
    url: 'Routine/RoutineEhrPerformanceSlv/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增绩效
 * @param data
 */
export function addRoutineEhrPerformanceSlv(data) {
  return request({
    url: 'Routine/RoutineEhrPerformanceSlv',
    method: 'post',
    data: data,
  })
}
/**
 * 修改绩效
 * @param data
 */
export function updateRoutineEhrPerformanceSlv(data) {
  return request({
    url: 'Routine/RoutineEhrPerformanceSlv',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取绩效详情
 * @param {Id}
 */
export function getRoutineEhrPerformanceSlv(id) {
  return request({
    url: 'Routine/RoutineEhrPerformanceSlv/' + id,
    method: 'get'
  })
}

/**
 * 删除绩效
 * @param {主键} pid
 */
export function delRoutineEhrPerformanceSlv(pid) {
  return request({
    url: 'Routine/RoutineEhrPerformanceSlv/delete/' + pid,
    method: 'delete'
  })
}
// 导出绩效
export async function exportRoutineEhrPerformanceSlv(query) {
  await downFile('Routine/RoutineEhrPerformanceSlv/export', { ...query })
}
