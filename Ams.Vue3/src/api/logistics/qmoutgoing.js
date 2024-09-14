import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 出货检验分页查询
 * @param {查询条件} data
 */
export function listQmOutgoing(query) {
  return request({
    url: 'Logistics/QmOutgoing/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增出货检验
 * @param data
 */
export function addQmOutgoing(data) {
  return request({
    url: 'Logistics/QmOutgoing',
    method: 'post',
    data: data,
  })
}
/**
 * 修改出货检验
 * @param data
 */
export function updateQmOutgoing(data) {
  return request({
    url: 'Logistics/QmOutgoing',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取出货检验详情
 * @param {Id}
 */
export function getQmOutgoing(id) {
  return request({
    url: 'Logistics/QmOutgoing/' + id,
    method: 'get'
  })
}

/**
 * 删除出货检验
 * @param {主键} pid
 */
export function delQmOutgoing(pid) {
  return request({
    url: 'Logistics/QmOutgoing/delete/' + pid,
    method: 'delete'
  })
}
// 导出出货检验
export async function exportQmOutgoing(query) {
  await downFile('Logistics/QmOutgoing/export', { ...query })
}
