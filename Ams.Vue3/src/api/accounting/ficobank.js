import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 银行分页查询
 * @param {查询条件} data
 */
export function listFicoBank(query) {
  return request({
    url: 'Accounting/FicoBank/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增银行
 * @param data
 */
export function addFicoBank(data) {
  return request({
    url: 'Accounting/FicoBank',
    method: 'post',
    data: data,
  })
}
/**
 * 修改银行
 * @param data
 */
export function updateFicoBank(data) {
  return request({
    url: 'Accounting/FicoBank',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取银行详情
 * @param {Id}
 */
export function getFicoBank(id) {
  return request({
    url: 'Accounting/FicoBank/' + id,
    method: 'get'
  })
}

/**
 * 删除银行
 * @param {主键} pid
 */
export function delFicoBank(pid) {
  return request({
    url: 'Accounting/FicoBank/delete/' + pid,
    method: 'delete'
  })
}
// 导出银行
export async function exportFicoBank(query) {
  await downFile('Accounting/FicoBank/export', { ...query })
}
