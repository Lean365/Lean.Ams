import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * bom成本核算分页查询
 * @param {查询条件} data
 */
export function listFicoBomCosting(query) {
  return request({
    url: 'Accounting/FicoBomCosting/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增bom成本核算
 * @param data
 */
export function addFicoBomCosting(data) {
  return request({
    url: 'Accounting/FicoBomCosting',
    method: 'post',
    data: data,
  })
}
/**
 * 修改bom成本核算
 * @param data
 */
export function updateFicoBomCosting(data) {
  return request({
    url: 'Accounting/FicoBomCosting',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取bom成本核算详情
 * @param {Id}
 */
export function getFicoBomCosting(id) {
  return request({
    url: 'Accounting/FicoBomCosting/' + id,
    method: 'get'
  })
}

/**
 * 删除bom成本核算
 * @param {主键} pid
 */
export function delFicoBomCosting(pid) {
  return request({
    url: 'Accounting/FicoBomCosting/delete/' + pid,
    method: 'delete'
  })
}
// 导出bom成本核算
export async function exportFicoBomCosting(query) {
  await downFile('Accounting/FicoBomCosting/export', { ...query })
}
