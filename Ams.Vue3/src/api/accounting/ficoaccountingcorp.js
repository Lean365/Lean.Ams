import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 公司科目分页查询
 * @param {查询条件} data
 */
export function listFicoAccountingCorp(query) {
  return request({
    url: 'Accounting/FicoAccountingCorp/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增公司科目
 * @param data
 */
export function addFicoAccountingCorp(data) {
  return request({
    url: 'Accounting/FicoAccountingCorp',
    method: 'post',
    data: data,
  })
}
/**
 * 修改公司科目
 * @param data
 */
export function updateFicoAccountingCorp(data) {
  return request({
    url: 'Accounting/FicoAccountingCorp',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取公司科目详情
 * @param {Id}
 */
export function getFicoAccountingCorp(id) {
  return request({
    url: 'Accounting/FicoAccountingCorp/' + id,
    method: 'get'
  })
}

/**
 * 删除公司科目
 * @param {主键} pid
 */
export function delFicoAccountingCorp(pid) {
  return request({
    url: 'Accounting/FicoAccountingCorp/delete/' + pid,
    method: 'delete'
  })
}
// 导出公司科目
export async function exportFicoAccountingCorp(query) {
  await downFile('Accounting/FicoAccountingCorp/export', { ...query })
}
