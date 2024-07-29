import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 利润中心分页查询
 * @param {查询条件} data
 */
export function listFicoProfitCenter(query) {
  return request({
    url: 'Accounting/FicoProfitCenter/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增利润中心
 * @param data
 */
export function addFicoProfitCenter(data) {
  return request({
    url: 'Accounting/FicoProfitCenter',
    method: 'post',
    data: data,
  })
}
/**
 * 修改利润中心
 * @param data
 */
export function updateFicoProfitCenter(data) {
  return request({
    url: 'Accounting/FicoProfitCenter',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取利润中心详情
 * @param {Id}
 */
export function getFicoProfitCenter(id) {
  return request({
    url: 'Accounting/FicoProfitCenter/' + id,
    method: 'get'
  })
}

/**
 * 删除利润中心
 * @param {主键} pid
 */
export function delFicoProfitCenter(pid) {
  return request({
    url: 'Accounting/FicoProfitCenter/delete/' + pid,
    method: 'delete'
  })
}
// 导出利润中心
export async function exportFicoProfitCenter(query) {
  await downFile('Accounting/FicoProfitCenter/export', { ...query })
}
