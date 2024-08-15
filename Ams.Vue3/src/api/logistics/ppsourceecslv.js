import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 从源设变分页查询
 * @param {查询条件} data
 */
export function listPpSourceEcSlv(query) {
  return request({
    url: 'Logistics/PpSourceEcSlv/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增从源设变
 * @param data
 */
export function addPpSourceEcSlv(data) {
  return request({
    url: 'Logistics/PpSourceEcSlv',
    method: 'post',
    data: data,
  })
}
/**
 * 修改从源设变
 * @param data
 */
export function updatePpSourceEcSlv(data) {
  return request({
    url: 'Logistics/PpSourceEcSlv',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取从源设变详情
 * @param {Id}
 */
export function getPpSourceEcSlv(id) {
  return request({
    url: 'Logistics/PpSourceEcSlv/' + id,
    method: 'get'
  })
}

/**
 * 删除从源设变
 * @param {主键} pid
 */
export function delPpSourceEcSlv(pid) {
  return request({
    url: 'Logistics/PpSourceEcSlv/delete/' + pid,
    method: 'delete'
  })
}
// 导出从源设变
export async function exportPpSourceEcSlv(query) {
  await downFile('Logistics/PpSourceEcSlv/export', { ...query })
}
