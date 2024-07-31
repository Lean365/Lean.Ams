import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 薪资分页查询
 * @param {查询条件} data
 */
export function listRoutineEhrPayroll(query) {
  return request({
    url: 'Routine/RoutineEhrPayroll/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增薪资
 * @param data
 */
export function addRoutineEhrPayroll(data) {
  return request({
    url: 'Routine/RoutineEhrPayroll',
    method: 'post',
    data: data,
  })
}
/**
 * 修改薪资
 * @param data
 */
export function updateRoutineEhrPayroll(data) {
  return request({
    url: 'Routine/RoutineEhrPayroll',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取薪资详情
 * @param {Id}
 */
export function getRoutineEhrPayroll(id) {
  return request({
    url: 'Routine/RoutineEhrPayroll/' + id,
    method: 'get'
  })
}

/**
 * 删除薪资
 * @param {主键} pid
 */
export function delRoutineEhrPayroll(pid) {
  return request({
    url: 'Routine/RoutineEhrPayroll/delete/' + pid,
    method: 'delete'
  })
}
// 导出薪资
export async function exportRoutineEhrPayroll(query) {
  await downFile('Routine/RoutineEhrPayroll/export', { ...query })
}
