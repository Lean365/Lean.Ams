import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 福利分页查询
 * @param {查询条件} data
 */
export function listRoutineEhrBenefits(query) {
  return request({
    url: 'Routine/RoutineEhrBenefits/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增福利
 * @param data
 */
export function addRoutineEhrBenefits(data) {
  return request({
    url: 'Routine/RoutineEhrBenefits',
    method: 'post',
    data: data,
  })
}
/**
 * 修改福利
 * @param data
 */
export function updateRoutineEhrBenefits(data) {
  return request({
    url: 'Routine/RoutineEhrBenefits',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取福利详情
 * @param {Id}
 */
export function getRoutineEhrBenefits(id) {
  return request({
    url: 'Routine/RoutineEhrBenefits/' + id,
    method: 'get'
  })
}

/**
 * 删除福利
 * @param {主键} pid
 */
export function delRoutineEhrBenefits(pid) {
  return request({
    url: 'Routine/RoutineEhrBenefits/delete/' + pid,
    method: 'delete'
  })
}
// 导出福利
export async function exportRoutineEhrBenefits(query) {
  await downFile('Routine/RoutineEhrBenefits/export', { ...query })
}
