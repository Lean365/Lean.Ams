import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 部门消耗分页查询
 * @param {查询条件} data
 */
export function listFicoDeptConsuming(query) {
  return request({
    url: 'Accounting/FicoDeptConsuming/list',
    method: 'get',
    params: query,
  })
}

/**
 * 获取部门消耗详情
 * @param {Id}
 */
export function getFicoDeptConsuming(id) {
  return request({
    url: 'Accounting/FicoDeptConsuming/' + id,
    method: 'get'
  })
}

// 导出部门消耗
export async function exportFicoDeptConsuming(query) {
  await downFile('Accounting/FicoDeptConsuming/export', { ...query })
}
