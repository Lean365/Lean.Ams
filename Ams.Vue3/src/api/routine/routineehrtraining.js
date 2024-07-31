import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 培训分页查询
 * @param {查询条件} data
 */
export function listRoutineEhrTraining(query) {
  return request({
    url: 'Routine/RoutineEhrTraining/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增培训
 * @param data
 */
export function addRoutineEhrTraining(data) {
  return request({
    url: 'Routine/RoutineEhrTraining',
    method: 'post',
    data: data,
  })
}
/**
 * 修改培训
 * @param data
 */
export function updateRoutineEhrTraining(data) {
  return request({
    url: 'Routine/RoutineEhrTraining',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取培训详情
 * @param {Id}
 */
export function getRoutineEhrTraining(id) {
  return request({
    url: 'Routine/RoutineEhrTraining/' + id,
    method: 'get'
  })
}

/**
 * 删除培训
 * @param {主键} pid
 */
export function delRoutineEhrTraining(pid) {
  return request({
    url: 'Routine/RoutineEhrTraining/delete/' + pid,
    method: 'delete'
  })
}
// 导出培训
export async function exportRoutineEhrTraining(query) {
  await downFile('Routine/RoutineEhrTraining/export', { ...query })
}
