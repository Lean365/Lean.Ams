import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 废弃部品分页查询
 * @param {查询条件} data
 */
export function listQmCostWaste(query) {
  return request({
    url: 'Logistics/QmCostWaste/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增废弃部品
 * @param data
 */
export function addQmCostWaste(data) {
  return request({
    url: 'Logistics/QmCostWaste',
    method: 'post',
    data: data,
  })
}
/**
 * 修改废弃部品
 * @param data
 */
export function updateQmCostWaste(data) {
  return request({
    url: 'Logistics/QmCostWaste',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取废弃部品详情
 * @param {Id}
 */
export function getQmCostWaste(id) {
  return request({
    url: 'Logistics/QmCostWaste/' + id,
    method: 'get'
  })
}

/**
 * 删除废弃部品
 * @param {主键} pid
 */
export function delQmCostWaste(pid) {
  return request({
    url: 'Logistics/QmCostWaste/delete/' + pid,
    method: 'delete'
  })
}
// 导出废弃部品
export async function exportQmCostWaste(query) {
  await downFile('Logistics/QmCostWaste/export', { ...query })
}
