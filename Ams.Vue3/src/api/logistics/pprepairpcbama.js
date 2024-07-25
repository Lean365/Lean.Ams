import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 修理日报ma分页查询
 * @param {查询条件} data
 */
export function listPpRepairPcbaMa(query) {
  return request({
    url: 'Logistics/PpRepairPcbaMa/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增修理日报ma
 * @param data
 */
export function addPpRepairPcbaMa(data) {
  return request({
    url: 'Logistics/PpRepairPcbaMa',
    method: 'post',
    data: data,
  })
}
/**
 * 修改修理日报ma
 * @param data
 */
export function updatePpRepairPcbaMa(data) {
  return request({
    url: 'Logistics/PpRepairPcbaMa',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取修理日报ma详情
 * @param {Id}
 */
export function getPpRepairPcbaMa(id) {
  return request({
    url: 'Logistics/PpRepairPcbaMa/' + id,
    method: 'get'
  })
}

/**
 * 删除修理日报ma
 * @param {主键} pid
 */
export function delPpRepairPcbaMa(pid) {
  return request({
    url: 'Logistics/PpRepairPcbaMa/delete/' + pid,
    method: 'delete'
  })
}
// 导出修理日报ma
export async function exportPpRepairPcbaMa(query) {
  await downFile('Logistics/PpRepairPcbaMa/export', { ...query })
}
