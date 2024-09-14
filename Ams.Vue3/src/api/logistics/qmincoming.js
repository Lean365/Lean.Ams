import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 进料检验分页查询
 * @param {查询条件} data
 */
export function listQmIncoming(query) {
  return request({
    url: 'Logistics/QmIncoming/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增进料检验
 * @param data
 */
export function addQmIncoming(data) {
  return request({
    url: 'Logistics/QmIncoming',
    method: 'post',
    data: data,
  })
}
/**
 * 修改进料检验
 * @param data
 */
export function updateQmIncoming(data) {
  return request({
    url: 'Logistics/QmIncoming',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取进料检验详情
 * @param {Id}
 */
export function getQmIncoming(id) {
  return request({
    url: 'Logistics/QmIncoming/' + id,
    method: 'get'
  })
}

/**
 * 删除进料检验
 * @param {主键} pid
 */
export function delQmIncoming(pid) {
  return request({
    url: 'Logistics/QmIncoming/delete/' + pid,
    method: 'delete'
  })
}
// 导出进料检验
export async function exportQmIncoming(query) {
  await downFile('Logistics/QmIncoming/export', { ...query })
}
