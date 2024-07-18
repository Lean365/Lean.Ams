import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 工资率分页查询
 * @param {查询条件} data
 */
export function listFicoWageRates(query) {
  return request({
    url: 'Accounting/FicoWageRates/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增工资率
 * @param data
 */
export function addFicoWageRates(data) {
  return request({
    url: 'Accounting/FicoWageRates',
    method: 'post',
    data: data,
  })
}
/**
 * 修改工资率
 * @param data
 */
export function updateFicoWageRates(data) {
  return request({
    url: 'Accounting/FicoWageRates',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取工资率详情
 * @param {Id}
 */
export function getFicoWageRates(id) {
  return request({
    url: 'Accounting/FicoWageRates/' + id,
    method: 'get'
  })
}

/**
 * 删除工资率
 * @param {主键} pid
 */
export function delFicoWageRates(pid) {
  return request({
    url: 'Accounting/FicoWageRates/delete/' + pid,
    method: 'delete'
  })
}
// 导出工资率
export async function exportFicoWageRates(query) {
  await downFile('Accounting/FicoWageRates/export', { ...query })
}
