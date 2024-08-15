import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * bom核算分页查询
 * @param {查询条件} data
 */
export function listFicoCostingBom(query) {
  return request({
    url: 'Accounting/FicoCostingBom/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增bom核算
 * @param data
 */
export function addFicoCostingBom(data) {
  return request({
    url: 'Accounting/FicoCostingBom',
    method: 'post',
    data: data,
  })
}
/**
 * 修改bom核算
 * @param data
 */
export function updateFicoCostingBom(data) {
  return request({
    url: 'Accounting/FicoCostingBom',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取bom核算详情
 * @param {Id}
 */
export function getFicoCostingBom(id) {
  return request({
    url: 'Accounting/FicoCostingBom/' + id,
    method: 'get'
  })
}

/**
 * 删除bom核算
 * @param {主键} pid
 */
export function delFicoCostingBom(pid) {
  return request({
    url: 'Accounting/FicoCostingBom/delete/' + pid,
    method: 'delete'
  })
}
// 导出bom核算
export async function exportFicoCostingBom(query) {
  await downFile('Accounting/FicoCostingBom/export', { ...query })
}
