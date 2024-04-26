import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 财务期间分页查询
* @param {查询条件} data
*/
export function listPeriod(query) {
  return request({
    url: 'accounting/Period/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增财务期间
* @param data
*/
export function addPeriod(data) {
  return request({
    url: 'accounting/Period',
    method: 'post',
    data: data,
  })
}
/**
* 修改财务期间
* @param data
*/
export function updatePeriod(data) {
  return request({
    url: 'accounting/Period',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取财务期间详情
* @param {Id}
*/
export function getPeriod(id) {
  return request({
    url: 'accounting/Period/' + id,
    method: 'get'
  })
}

/**
* 删除财务期间
* @param {主键} pid
*/
export function delPeriod(pid) {
  return request({
    url: 'accounting/Period/delete/' + pid,
    method: 'delete'
  })
}
// 导出财务期间
export async function exportPeriod(query) {
  await downFile('accounting/Period/export', { ...query })
}
