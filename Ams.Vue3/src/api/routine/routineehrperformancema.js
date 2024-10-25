import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 绩效分页查询
 * @param {查询条件} data
 */
export function listRoutineEhrPerformanceMa(query) {
  return request({
    url: 'Routine/RoutineEhrPerformanceMa/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增绩效
 * @param data
 */
export function addRoutineEhrPerformanceMa(data) {
  return request({
    url: 'Routine/RoutineEhrPerformanceMa',
    method: 'post',
    data: data,
  })
}
/**
 * 修改绩效
 * @param data
 */
export function updateRoutineEhrPerformanceMa(data) {
  return request({
    url: 'Routine/RoutineEhrPerformanceMa',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取绩效详情
 * @param {Id}
 */
export function getRoutineEhrPerformanceMa(id) {
  return request({
    url: 'Routine/RoutineEhrPerformanceMa/' + id,
    method: 'get'
  })
}

/**
 * 删除绩效
 * @param {主键} pid
 */
export function delRoutineEhrPerformanceMa(pid) {
  return request({
    url: 'Routine/RoutineEhrPerformanceMa/delete/' + pid,
    method: 'delete'
  })
}
// 导出绩效
export async function exportRoutineEhrPerformanceMa(query) {
  await downFile('Routine/RoutineEhrPerformanceMa/export', { ...query })
}
