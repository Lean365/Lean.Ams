import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 会计科目分页查询
* @param {查询条件} data
*/
export function listAccountingTitle(query) {
  return request({
    url: 'accounting/AccountingTitle/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增会计科目
* @param data
*/
export function addAccountingTitle(data) {
  return request({
    url: 'accounting/AccountingTitle',
    method: 'post',
    data: data,
  })
}
/**
* 修改会计科目
* @param data
*/
export function updateAccountingTitle(data) {
  return request({
    url: 'accounting/AccountingTitle',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取会计科目详情
* @param {Id}
*/
export function getAccountingTitle(id) {
  return request({
    url: 'accounting/AccountingTitle/' + id,
    method: 'get'
  })
}

/**
* 删除会计科目
* @param {主键} pid
*/
export function delAccountingTitle(pid) {
  return request({
    url: 'accounting/AccountingTitle/delete/' + pid,
    method: 'delete'
  })
}
// 导出会计科目
export async function exportAccountingTitle(query) {
  await downFile('accounting/AccountingTitle/export', { ...query })
}
