import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 资产类别分页查询
 * @param {查询条件} data
 */
export function listFicoAssetsCategory(query) {
  return request({
    url: 'Accounting/FicoAssetsCategory/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增资产类别
 * @param data
 */
export function addFicoAssetsCategory(data) {
  return request({
    url: 'Accounting/FicoAssetsCategory',
    method: 'post',
    data: data,
  })
}
/**
 * 修改资产类别
 * @param data
 */
export function updateFicoAssetsCategory(data) {
  return request({
    url: 'Accounting/FicoAssetsCategory',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取资产类别详情
 * @param {Id}
 */
export function getFicoAssetsCategory(id) {
  return request({
    url: 'Accounting/FicoAssetsCategory/' + id,
    method: 'get'
  })
}

/**
 * 删除资产类别
 * @param {主键} pid
 */
export function delFicoAssetsCategory(pid) {
  return request({
    url: 'Accounting/FicoAssetsCategory/delete/' + pid,
    method: 'delete'
  })
}
// 导出资产类别
export async function exportFicoAssetsCategory(query) {
  await downFile('Accounting/FicoAssetsCategory/export', { ...query })
}
