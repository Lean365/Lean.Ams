import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 考勤分页查询
 * @param {查询条件} data
 */
export function listRoutineEhrAttendance(query) {
  return request({
    url: 'Routine/RoutineEhrAttendance/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增考勤
 * @param data
 */
export function addRoutineEhrAttendance(data) {
  return request({
    url: 'Routine/RoutineEhrAttendance',
    method: 'post',
    data: data,
  })
}
/**
 * 修改考勤
 * @param data
 */
export function updateRoutineEhrAttendance(data) {
  return request({
    url: 'Routine/RoutineEhrAttendance',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取考勤详情
 * @param {Id}
 */
export function getRoutineEhrAttendance(id) {
  return request({
    url: 'Routine/RoutineEhrAttendance/' + id,
    method: 'get'
  })
}

/**
 * 删除考勤
 * @param {主键} pid
 */
export function delRoutineEhrAttendance(pid) {
  return request({
    url: 'Routine/RoutineEhrAttendance/delete/' + pid,
    method: 'delete'
  })
}
// 导出考勤
export async function exportRoutineEhrAttendance(query) {
  await downFile('Routine/RoutineEhrAttendance/export', { ...query })
}
