import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 生产工单分页查询
* @param {查询条件} data
*/
export function listOrder(query) {
  return request({
    url: 'logistics/Order/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增生产工单
* @param data
*/
export function addOrder(data) {
  return request({
    url: 'logistics/Order',
    method: 'post',
    data: data,
  })
}
/**
* 修改生产工单
* @param data
*/
export function updateOrder(data) {
  return request({
    url: 'logistics/Order',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取生产工单详情
* @param {Id}
*/
export function getOrder(id) {
  return request({
    url: 'logistics/Order/' + id,
    method: 'get'
  })
}

/**
* 删除生产工单
* @param {主键} pid
*/
export function delOrder(pid) {
  return request({
    url: 'logistics/Order/delete/' + pid,
    method: 'delete'
  })
}
// 导出生产工单
export async function exportOrder(query) {
  await downFile('logistics/Order/export', { ...query })
}
