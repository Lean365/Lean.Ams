import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 财务期间分页查询
 * @param {查询条件} data
 */
export function listFicoFinancialPeriod(query) {
  return request({
    url: 'Accounting/FicoFinancialPeriod/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增财务期间
 * @param data
 */
export function addFicoFinancialPeriod(data) {
  return request({
    url: 'Accounting/FicoFinancialPeriod',
    method: 'post',
    data: data,
  })
}
/**
 * 修改财务期间
 * @param data
 */
export function updateFicoFinancialPeriod(data) {
  return request({
    url: 'Accounting/FicoFinancialPeriod',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取财务期间详情
 * @param {Id}
 */
export function getFicoFinancialPeriod(id) {
  return request({
    url: 'Accounting/FicoFinancialPeriod/' + id,
    method: 'get'
  })
}

/**
 * 删除财务期间
 * @param {主键} pid
 */
export function delFicoFinancialPeriod(pid) {
  return request({
    url: 'Accounting/FicoFinancialPeriod/delete/' + pid,
    method: 'delete'
  })
}
// 导出财务期间
export async function exportFicoFinancialPeriod(query) {
  await downFile('Accounting/FicoFinancialPeriod/export', { ...query })
}