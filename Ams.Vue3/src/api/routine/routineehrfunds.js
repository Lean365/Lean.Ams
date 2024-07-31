import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 公积金分页查询
 * @param {查询条件} data
 */
export function listRoutineEhrFunds(query) {
  return request({
    url: 'Routine/RoutineEhrFunds/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增公积金
 * @param data
 */
export function addRoutineEhrFunds(data) {
  return request({
    url: 'Routine/RoutineEhrFunds',
    method: 'post',
    data: data,
  })
}
/**
 * 修改公积金
 * @param data
 */
export function updateRoutineEhrFunds(data) {
  return request({
    url: 'Routine/RoutineEhrFunds',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取公积金详情
 * @param {Id}
 */
export function getRoutineEhrFunds(id) {
  return request({
    url: 'Routine/RoutineEhrFunds/' + id,
    method: 'get'
  })
}

/**
 * 删除公积金
 * @param {主键} pid
 */
export function delRoutineEhrFunds(pid) {
  return request({
    url: 'Routine/RoutineEhrFunds/delete/' + pid,
    method: 'delete'
  })
}
// 导出公积金
export async function exportRoutineEhrFunds(query) {
  await downFile('Routine/RoutineEhrFunds/export', { ...query })
}
