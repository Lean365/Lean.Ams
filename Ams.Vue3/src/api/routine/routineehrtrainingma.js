import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 培训分页查询
 * @param {查询条件} data
 */
export function listRoutineEhrTrainingMa(query) {
  return request({
    url: 'Routine/RoutineEhrTrainingMa/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增培训
 * @param data
 */
export function addRoutineEhrTrainingMa(data) {
  return request({
    url: 'Routine/RoutineEhrTrainingMa',
    method: 'post',
    data: data,
  })
}
/**
 * 修改培训
 * @param data
 */
export function updateRoutineEhrTrainingMa(data) {
  return request({
    url: 'Routine/RoutineEhrTrainingMa',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取培训详情
 * @param {Id}
 */
export function getRoutineEhrTrainingMa(id) {
  return request({
    url: 'Routine/RoutineEhrTrainingMa/' + id,
    method: 'get'
  })
}

/**
 * 删除培训
 * @param {主键} pid
 */
export function delRoutineEhrTrainingMa(pid) {
  return request({
    url: 'Routine/RoutineEhrTrainingMa/delete/' + pid,
    method: 'delete'
  })
}
// 导出培训
export async function exportRoutineEhrTrainingMa(query) {
  await downFile('Routine/RoutineEhrTrainingMa/export', { ...query })
}
