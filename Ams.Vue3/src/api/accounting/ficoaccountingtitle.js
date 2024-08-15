import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 会计科目分页查询
 * @param {查询条件} data
 */
export function listFicoAccountingTitle(query) {
  return request({
    url: 'Accounting/FicoAccountingTitle/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增会计科目
 * @param data
 */
export function addFicoAccountingTitle(data) {
  return request({
    url: 'Accounting/FicoAccountingTitle',
    method: 'post',
    data: data,
  })
}
/**
 * 修改会计科目
 * @param data
 */
export function updateFicoAccountingTitle(data) {
  return request({
    url: 'Accounting/FicoAccountingTitle',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取会计科目详情
 * @param {Id}
 */
export function getFicoAccountingTitle(id) {
  return request({
    url: 'Accounting/FicoAccountingTitle/' + id,
    method: 'get'
  })
}

/**
 * 删除会计科目
 * @param {主键} pid
 */
export function delFicoAccountingTitle(pid) {
  return request({
    url: 'Accounting/FicoAccountingTitle/delete/' + pid,
    method: 'delete'
  })
}
// 导出会计科目
export async function exportFicoAccountingTitle(query) {
  await downFile('Accounting/FicoAccountingTitle/export', { ...query })
}
