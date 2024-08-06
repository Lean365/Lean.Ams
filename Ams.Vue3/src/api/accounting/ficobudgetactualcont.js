import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 实际对比分页查询
 * @param {查询条件} data
 */
export function listFicoBudgetActualCont(query) {
  return request({
    url: 'Accounting/FicoBudgetActualCont/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增实际对比
 * @param data
 */
export function addFicoBudgetActualCont(data) {
  return request({
    url: 'Accounting/FicoBudgetActualCont',
    method: 'post',
    data: data,
  })
}
/**
 * 修改实际对比
 * @param data
 */
export function updateFicoBudgetActualCont(data) {
  return request({
    url: 'Accounting/FicoBudgetActualCont',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取实际对比详情
 * @param {Id}
 */
export function getFicoBudgetActualCont(id) {
  return request({
    url: 'Accounting/FicoBudgetActualCont/' + id,
    method: 'get'
  })
}

/**
 * 删除实际对比
 * @param {主键} pid
 */
export function delFicoBudgetActualCont(pid) {
  return request({
    url: 'Accounting/FicoBudgetActualCont/delete/' + pid,
    method: 'delete'
  })
}
// 导出实际对比
export async function exportFicoBudgetActualCont(query) {
  await downFile('Accounting/FicoBudgetActualCont/export', { ...query })
}
