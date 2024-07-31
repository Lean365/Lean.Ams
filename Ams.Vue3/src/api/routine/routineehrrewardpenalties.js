import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 奖惩分页查询
 * @param {查询条件} data
 */
export function listRoutineEhrRewardPenalties(query) {
  return request({
    url: 'Routine/RoutineEhrRewardPenalties/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增奖惩
 * @param data
 */
export function addRoutineEhrRewardPenalties(data) {
  return request({
    url: 'Routine/RoutineEhrRewardPenalties',
    method: 'post',
    data: data,
  })
}
/**
 * 修改奖惩
 * @param data
 */
export function updateRoutineEhrRewardPenalties(data) {
  return request({
    url: 'Routine/RoutineEhrRewardPenalties',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取奖惩详情
 * @param {Id}
 */
export function getRoutineEhrRewardPenalties(id) {
  return request({
    url: 'Routine/RoutineEhrRewardPenalties/' + id,
    method: 'get'
  })
}

/**
 * 删除奖惩
 * @param {主键} pid
 */
export function delRoutineEhrRewardPenalties(pid) {
  return request({
    url: 'Routine/RoutineEhrRewardPenalties/delete/' + pid,
    method: 'delete'
  })
}
// 导出奖惩
export async function exportRoutineEhrRewardPenalties(query) {
  await downFile('Routine/RoutineEhrRewardPenalties/export', { ...query })
}
