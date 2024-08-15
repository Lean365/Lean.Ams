import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 部门消耗分页查询
 * @param {查询条件} data
 */
export function listFicoCostingDeptConsuming(query) {
  return request({
    url: 'Accounting/FicoCostingDeptConsuming/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增部门消耗
 * @param data
 */
export function addFicoCostingDeptConsuming(data) {
  return request({
    url: 'Accounting/FicoCostingDeptConsuming',
    method: 'post',
    data: data,
  })
}
/**
 * 修改部门消耗
 * @param data
 */
export function updateFicoCostingDeptConsuming(data) {
  return request({
    url: 'Accounting/FicoCostingDeptConsuming',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取部门消耗详情
 * @param {Id}
 */
export function getFicoCostingDeptConsuming(id) {
  return request({
    url: 'Accounting/FicoCostingDeptConsuming/' + id,
    method: 'get'
  })
}

/**
 * 删除部门消耗
 * @param {主键} pid
 */
export function delFicoCostingDeptConsuming(pid) {
  return request({
    url: 'Accounting/FicoCostingDeptConsuming/delete/' + pid,
    method: 'delete'
  })
}
// 导出部门消耗
export async function exportFicoCostingDeptConsuming(query) {
  await downFile('Accounting/FicoCostingDeptConsuming/export', { ...query })
}
