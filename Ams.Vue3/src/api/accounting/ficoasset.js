import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 固定资产分页查询
 * @param {查询条件} data
 */
export function listFicoAsset(query) {
  return request({
    url: 'Accounting/FicoAsset/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增固定资产
 * @param data
 */
export function addFicoAsset(data) {
  return request({
    url: 'Accounting/FicoAsset',
    method: 'post',
    data: data,
  })
}
/**
 * 修改固定资产
 * @param data
 */
export function updateFicoAsset(data) {
  return request({
    url: 'Accounting/FicoAsset',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取固定资产详情
 * @param {Id}
 */
export function getFicoAsset(id) {
  return request({
    url: 'Accounting/FicoAsset/' + id,
    method: 'get'
  })
}

/**
 * 删除固定资产
 * @param {主键} pid
 */
export function delFicoAsset(pid) {
  return request({
    url: 'Accounting/FicoAsset/delete/' + pid,
    method: 'delete'
  })
}
// 导出固定资产
export async function exportFicoAsset(query) {
  await downFile('Accounting/FicoAsset/export', { ...query })
}
