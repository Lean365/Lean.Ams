import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 培训分页查询
 * @param {查询条件} data
 */
export function listRoutineEhrTrainingSlv(query) {
  return request({
    url: 'Routine/RoutineEhrTrainingSlv/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增培训
 * @param data
 */
export function addRoutineEhrTrainingSlv(data) {
  return request({
    url: 'Routine/RoutineEhrTrainingSlv',
    method: 'post',
    data: data,
  })
}
/**
 * 修改培训
 * @param data
 */
export function updateRoutineEhrTrainingSlv(data) {
  return request({
    url: 'Routine/RoutineEhrTrainingSlv',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取培训详情
 * @param {Id}
 */
export function getRoutineEhrTrainingSlv(id) {
  return request({
    url: 'Routine/RoutineEhrTrainingSlv/' + id,
    method: 'get'
  })
}

/**
 * 删除培训
 * @param {主键} pid
 */
export function delRoutineEhrTrainingSlv(pid) {
  return request({
    url: 'Routine/RoutineEhrTrainingSlv/delete/' + pid,
    method: 'delete'
  })
}
// 导出培训
export async function exportRoutineEhrTrainingSlv(query) {
  await downFile('Routine/RoutineEhrTrainingSlv/export', { ...query })
}
