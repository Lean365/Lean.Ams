import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 月度资产分页查询
 * @param {查询条件} data
 */
export function listFicoMonthlyAssets(query) {
  return request({
    url: 'Accounting/FicoMonthlyAssets/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增月度资产
 * @param data
 */
export function addFicoMonthlyAssets(data) {
  return request({
    url: 'Accounting/FicoMonthlyAssets',
    method: 'post',
    data: data,
  })
}
/**
 * 修改月度资产
 * @param data
 */
export function updateFicoMonthlyAssets(data) {
  return request({
    url: 'Accounting/FicoMonthlyAssets',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取月度资产详情
 * @param {Id}
 */
export function getFicoMonthlyAssets(id) {
  return request({
    url: 'Accounting/FicoMonthlyAssets/' + id,
    method: 'get'
  })
}

/**
 * 删除月度资产
 * @param {主键} pid
 */
export function delFicoMonthlyAssets(pid) {
  return request({
    url: 'Accounting/FicoMonthlyAssets/delete/' + pid,
    method: 'delete'
  })
}
// 导出月度资产
export async function exportFicoMonthlyAssets(query) {
  await downFile('Accounting/FicoMonthlyAssets/export', { ...query })
}
