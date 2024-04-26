import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 固定资产分页查询
* @param {查询条件} data
*/
export function listAsset(query) {
  return request({
    url: 'accounting/Asset/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增固定资产
* @param data
*/
export function addAsset(data) {
  return request({
    url: 'accounting/Asset',
    method: 'post',
    data: data,
  })
}
/**
* 修改固定资产
* @param data
*/
export function updateAsset(data) {
  return request({
    url: 'accounting/Asset',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取固定资产详情
* @param {Id}
*/
export function getAsset(id) {
  return request({
    url: 'accounting/Asset/' + id,
    method: 'get'
  })
}

/**
* 删除固定资产
* @param {主键} pid
*/
export function delAsset(pid) {
  return request({
    url: 'accounting/Asset/delete/' + pid,
    method: 'delete'
  })
}
// 导出固定资产
export async function exportAsset(query) {
  await downFile('accounting/Asset/export', { ...query })
}
