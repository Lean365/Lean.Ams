import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 预算科目分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetAccounting(query) {
  return request({
    url: 'Accounting/FicoBudgetAccounting/list',
    method: 'get',
    params: query,
  })
}

/**
 * 预算科目tree查询
 * @param {查询条件} data
 */
export function treelistFicoBudgetAccounting(query) {
  return request({
    url: 'Accounting/FicoBudgetAccounting/treelist',
    method: 'get',
    params: query,
  })
}
// 查询部门下拉树结构
export function treeselectFicoBudgetAccounting(query) {
  return request({
    url: '/Accounting/FicoBudgetAccounting/treeselect',
    method: 'get',
    params: query,
  })
}
/**
 * 新增预算科目
 * @param data
 */
export function addFicoBudgetAccounting(data) {
  return request({
    url: 'Accounting/FicoBudgetAccounting',
    method: 'post',
    data: data,
  })
}
/**
 * 修改预算科目
 * @param data
 */
export function updateFicoBudgetAccounting(data) {
  return request({
    url: 'Accounting/FicoBudgetAccounting',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取预算科目详情
 * @param {Id}
 */
export function getFicoBudgetAccounting(id) {
  return request({
    url: 'Accounting/FicoBudgetAccounting/' + id,
    method: 'get'
  })
}

/**
 * 删除预算科目
 * @param {主键} pid
 */
export function delFicoBudgetAccounting(pid) {
  return request({
    url: 'Accounting/FicoBudgetAccounting/delete/' + pid,
    method: 'delete'
  })
}
// 导出预算科目
export async function exportFicoBudgetAccounting(query) {
  await downFile('Accounting/FicoBudgetAccounting/export', { ...query })
}
