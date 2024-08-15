import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 人事分页查询
 * @param {查询条件} data
 */
export function listRoutineEhrEmployee(query) {
  return request({
    url: 'Routine/RoutineEhrEmployee/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增人事
 * @param data
 */
export function addRoutineEhrEmployee(data) {
  return request({
    url: 'Routine/RoutineEhrEmployee',
    method: 'post',
    data: data,
  })
}
/**
 * 修改人事
 * @param data
 */
export function updateRoutineEhrEmployee(data) {
  return request({
    url: 'Routine/RoutineEhrEmployee',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取人事详情
 * @param {Id}
 */
export function getRoutineEhrEmployee(id) {
  return request({
    url: 'Routine/RoutineEhrEmployee/' + id,
    method: 'get'
  })
}

/**
 * 删除人事
 * @param {主键} pid
 */
export function delRoutineEhrEmployee(pid) {
  return request({
    url: 'Routine/RoutineEhrEmployee/delete/' + pid,
    method: 'delete'
  })
}
// 导出人事
export async function exportRoutineEhrEmployee(query) {
  await downFile('Routine/RoutineEhrEmployee/export', { ...query })
}
