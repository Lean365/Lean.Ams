import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 废弃部品分页查询
 * @param {查询条件} data
 */
export function listQmCostDiscard(query) {
  return request({
    url: 'Logistics/QmCostDiscard/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增废弃部品
 * @param data
 */
export function addQmCostDiscard(data) {
  return request({
    url: 'Logistics/QmCostDiscard',
    method: 'post',
    data: data,
  })
}
/**
 * 修改废弃部品
 * @param data
 */
export function updateQmCostDiscard(data) {
  return request({
    url: 'Logistics/QmCostDiscard',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取废弃部品详情
 * @param {Id}
 */
export function getQmCostDiscard(id) {
  return request({
    url: 'Logistics/QmCostDiscard/' + id,
    method: 'get'
  })
}

/**
 * 删除废弃部品
 * @param {主键} pid
 */
export function delQmCostDiscard(pid) {
  return request({
    url: 'Logistics/QmCostDiscard/delete/' + pid,
    method: 'delete'
  })
}
// 导出废弃部品
export async function exportQmCostDiscard(query) {
  await downFile('Logistics/QmCostDiscard/export', { ...query })
}
