import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 人事分页查询
 * @param {查询条件} data
 */
export function listEhrEmployee(query) {
  return request({
    url: 'Routine/EhrEmployee/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增人事
 * @param data
 */
export function addEhrEmployee(data) {
  return request({
    url: 'Routine/EhrEmployee',
    method: 'post',
    data: data,
  })
}
/**
 * 修改人事
 * @param data
 */
export function updateEhrEmployee(data) {
  return request({
    url: 'Routine/EhrEmployee',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取人事详情
 * @param {Id}
 */
export function getEhrEmployee(id) {
  return request({
    url: 'Routine/EhrEmployee/' + id,
    method: 'get'
  })
}

/**
 * 删除人事
 * @param {主键} pid
 */
export function delEhrEmployee(pid) {
  return request({
    url: 'Routine/EhrEmployee/delete/' + pid,
    method: 'delete'
  })
}
// 导出人事
export async function exportEhrEmployee(query) {
  await downFile('Routine/EhrEmployee/export', { ...query })
}
