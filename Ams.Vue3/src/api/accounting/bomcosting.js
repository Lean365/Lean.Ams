import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* bom成本核算分页查询
* @param {查询条件} data
*/
export function listBomCosting(query) {
  return request({
    url: 'accounting/BomCosting/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增bom成本核算
* @param data
*/
export function addBomCosting(data) {
  return request({
    url: 'accounting/BomCosting',
    method: 'post',
    data: data,
  })
}
/**
* 修改bom成本核算
* @param data
*/
export function updateBomCosting(data) {
  return request({
    url: 'accounting/BomCosting',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取bom成本核算详情
* @param {Id}
*/
export function getBomCosting(id) {
  return request({
    url: 'accounting/BomCosting/' + id,
    method: 'get'
  })
}

/**
* 删除bom成本核算
* @param {主键} pid
*/
export function delBomCosting(pid) {
  return request({
    url: 'accounting/BomCosting/delete/' + pid,
    method: 'delete'
  })
}
// 导出bom成本核算
export async function exportBomCosting(query) {
  await downFile('accounting/BomCosting/export', { ...query })
}
