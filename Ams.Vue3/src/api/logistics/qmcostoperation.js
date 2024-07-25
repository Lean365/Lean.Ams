import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 品质业务分页查询
 * @param {查询条件} data
 */
export function listQmCostOperation(query) {
  return request({
    url: 'Logistics/QmCostOperation/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增品质业务
 * @param data
 */
export function addQmCostOperation(data) {
  return request({
    url: 'Logistics/QmCostOperation',
    method: 'post',
    data: data,
  })
}
/**
 * 修改品质业务
 * @param data
 */
export function updateQmCostOperation(data) {
  return request({
    url: 'Logistics/QmCostOperation',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取品质业务详情
 * @param {Id}
 */
export function getQmCostOperation(id) {
  return request({
    url: 'Logistics/QmCostOperation/' + id,
    method: 'get'
  })
}

/**
 * 删除品质业务
 * @param {主键} pid
 */
export function delQmCostOperation(pid) {
  return request({
    url: 'Logistics/QmCostOperation/delete/' + pid,
    method: 'delete'
  })
}
// 导出品质业务
export async function exportQmCostOperation(query) {
  await downFile('Logistics/QmCostOperation/export', { ...query })
}
