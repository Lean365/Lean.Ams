import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 机构目标分页查询
 * @param {查询条件} data
 */
export function listInstTarget(query) {
  return request({
    url: 'Routine/InstTarget/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增机构目标
 * @param data
 */
export function addInstTarget(data) {
  return request({
    url: 'Routine/InstTarget',
    method: 'post',
    data: data,
  })
}
/**
 * 修改机构目标
 * @param data
 */
export function updateInstTarget(data) {
  return request({
    url: 'Routine/InstTarget',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取机构目标详情
 * @param {Id}
 */
export function getInstTarget(id) {
  return request({
    url: 'Routine/InstTarget/' + id,
    method: 'get'
  })
}

/**
 * 删除机构目标
 * @param {主键} pid
 */
export function delInstTarget(pid) {
  return request({
    url: 'Routine/InstTarget/delete/' + pid,
    method: 'delete'
  })
}
// 导出机构目标
export async function exportInstTarget(query) {
  await downFile('Routine/InstTarget/export', { ...query })
}
