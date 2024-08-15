import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 检查日报ma分页查询
 * @param {查询条件} data
 */
export function listPpInspPcbaMa(query) {
  return request({
    url: 'Logistics/PpInspPcbaMa/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增检查日报ma
 * @param data
 */
export function addPpInspPcbaMa(data) {
  return request({
    url: 'Logistics/PpInspPcbaMa',
    method: 'post',
    data: data,
  })
}
/**
 * 修改检查日报ma
 * @param data
 */
export function updatePpInspPcbaMa(data) {
  return request({
    url: 'Logistics/PpInspPcbaMa',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取检查日报ma详情
 * @param {Id}
 */
export function getPpInspPcbaMa(id) {
  return request({
    url: 'Logistics/PpInspPcbaMa/' + id,
    method: 'get'
  })
}

/**
 * 删除检查日报ma
 * @param {主键} pid
 */
export function delPpInspPcbaMa(pid) {
  return request({
    url: 'Logistics/PpInspPcbaMa/delete/' + pid,
    method: 'delete'
  })
}
// 导出检查日报ma
export async function exportPpInspPcbaMa(query) {
  await downFile('Logistics/PpInspPcbaMa/export', { ...query })
}
