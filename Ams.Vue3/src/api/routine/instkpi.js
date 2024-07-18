import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * KPI分页查询
 * @param {查询条件} data
 */
export function listInstKpi(query) {
  return request({
    url: 'Routine/InstKpi/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增KPI
 * @param data
 */
export function addInstKpi(data) {
  return request({
    url: 'Routine/InstKpi',
    method: 'post',
    data: data,
  })
}
/**
 * 修改KPI
 * @param data
 */
export function updateInstKpi(data) {
  return request({
    url: 'Routine/InstKpi',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取KPI详情
 * @param {Id}
 */
export function getInstKpi(id) {
  return request({
    url: 'Routine/InstKpi/' + id,
    method: 'get'
  })
}

/**
 * 删除KPI
 * @param {主键} pid
 */
export function delInstKpi(pid) {
  return request({
    url: 'Routine/InstKpi/delete/' + pid,
    method: 'delete'
  })
}
// 导出KPI
export async function exportInstKpi(query) {
  await downFile('Routine/InstKpi/export', { ...query })
}
