import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 生产班组分页查询
 * @param {查询条件} data
 */
export function listPpLine(query) {
  return request({
    url: 'Logistics/PpLine/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增生产班组
 * @param data
 */
export function addPpLine(data) {
  return request({
    url: 'Logistics/PpLine',
    method: 'post',
    data: data,
  })
}
/**
 * 修改生产班组
 * @param data
 */
export function updatePpLine(data) {
  return request({
    url: 'Logistics/PpLine',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取生产班组详情
 * @param {Id}
 */
export function getPpLine(id) {
  return request({
    url: 'Logistics/PpLine/' + id,
    method: 'get'
  })
}

/**
 * 删除生产班组
 * @param {主键} pid
 */
export function delPpLine(pid) {
  return request({
    url: 'Logistics/PpLine/delete/' + pid,
    method: 'delete'
  })
}
// 导出生产班组
export async function exportPpLine(query) {
  await downFile('Logistics/PpLine/export', { ...query })
}
