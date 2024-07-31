import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 招聘分页查询
 * @param {查询条件} data
 */
export function listRoutineEhrRecruitment(query) {
  return request({
    url: 'Routine/RoutineEhrRecruitment/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增招聘
 * @param data
 */
export function addRoutineEhrRecruitment(data) {
  return request({
    url: 'Routine/RoutineEhrRecruitment',
    method: 'post',
    data: data,
  })
}
/**
 * 修改招聘
 * @param data
 */
export function updateRoutineEhrRecruitment(data) {
  return request({
    url: 'Routine/RoutineEhrRecruitment',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取招聘详情
 * @param {Id}
 */
export function getRoutineEhrRecruitment(id) {
  return request({
    url: 'Routine/RoutineEhrRecruitment/' + id,
    method: 'get'
  })
}

/**
 * 删除招聘
 * @param {主键} pid
 */
export function delRoutineEhrRecruitment(pid) {
  return request({
    url: 'Routine/RoutineEhrRecruitment/delete/' + pid,
    method: 'delete'
  })
}
// 导出招聘
export async function exportRoutineEhrRecruitment(query) {
  await downFile('Routine/RoutineEhrRecruitment/export', { ...query })
}
