import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 主源设变分页查询
 * @param {查询条件} data
 */
export function listPpSourceEcMa(query) {
  return request({
    url: 'Logistics/PpSourceEcMa/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增主源设变
 * @param data
 */
export function addPpSourceEcMa(data) {
  return request({
    url: 'Logistics/PpSourceEcMa',
    method: 'post',
    data: data,
  })
}
/**
 * 修改主源设变
 * @param data
 */
export function updatePpSourceEcMa(data) {
  return request({
    url: 'Logistics/PpSourceEcMa',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取主源设变详情
 * @param {Id}
 */
export function getPpSourceEcMa(id) {
  return request({
    url: 'Logistics/PpSourceEcMa/' + id,
    method: 'get'
  })
}

/**
 * 删除主源设变
 * @param {主键} pid
 */
export function delPpSourceEcMa(pid) {
  return request({
    url: 'Logistics/PpSourceEcMa/delete/' + pid,
    method: 'delete'
  })
}
// 导出主源设变
export async function exportPpSourceEcMa(query) {
  await downFile('Logistics/PpSourceEcMa/export', { ...query })
}
