import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 资产预算分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetAssetsSlv(query) {
  return request({
    url: 'Accounting/FicoBudgetAssetsSlv/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增资产预算
 * @param data
 */
export function addFicoBudgetAssetsSlv(data) {
  return request({
    url: 'Accounting/FicoBudgetAssetsSlv',
    method: 'post',
    data: data,
  })
}
/**
 * 修改资产预算
 * @param data
 */
export function updateFicoBudgetAssetsSlv(data) {
  return request({
    url: 'Accounting/FicoBudgetAssetsSlv',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取资产预算详情
 * @param {Id}
 */
export function getFicoBudgetAssetsSlv(id) {
  return request({
    url: 'Accounting/FicoBudgetAssetsSlv/' + id,
    method: 'get'
  })
}

/**
 * 删除资产预算
 * @param {主键} pid
 */
export function delFicoBudgetAssetsSlv(pid) {
  return request({
    url: 'Accounting/FicoBudgetAssetsSlv/delete/' + pid,
    method: 'delete'
  })
}
// 导出资产预算
export async function exportFicoBudgetAssetsSlv(query) {
  await downFile('Accounting/FicoBudgetAssetsSlv/export', { ...query })
}
