import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 社保分页查询
 * @param {查询条件} data
 */
export function listRoutineEhrSocialSecurity(query) {
  return request({
    url: 'Routine/RoutineEhrSocialSecurity/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增社保
 * @param data
 */
export function addRoutineEhrSocialSecurity(data) {
  return request({
    url: 'Routine/RoutineEhrSocialSecurity',
    method: 'post',
    data: data,
  })
}
/**
 * 修改社保
 * @param data
 */
export function updateRoutineEhrSocialSecurity(data) {
  return request({
    url: 'Routine/RoutineEhrSocialSecurity',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取社保详情
 * @param {Id}
 */
export function getRoutineEhrSocialSecurity(id) {
  return request({
    url: 'Routine/RoutineEhrSocialSecurity/' + id,
    method: 'get'
  })
}

/**
 * 删除社保
 * @param {主键} pid
 */
export function delRoutineEhrSocialSecurity(pid) {
  return request({
    url: 'Routine/RoutineEhrSocialSecurity/delete/' + pid,
    method: 'delete'
  })
}
// 导出社保
export async function exportRoutineEhrSocialSecurity(query) {
  await downFile('Routine/RoutineEhrSocialSecurity/export', { ...query })
}
