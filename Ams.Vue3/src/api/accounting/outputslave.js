import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* oph从表分页查询
* @param {查询条件} data
*/
export function listOutputSlave(query) {
  return request({
    url: 'accounting/OutputSlave/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增oph从表
* @param data
*/
export function addOutputSlave(data) {
  return request({
    url: 'accounting/OutputSlave',
    method: 'post',
    data: data,
  })
}
/**
* 修改oph从表
* @param data
*/
export function updateOutputSlave(data) {
  return request({
    url: 'accounting/OutputSlave',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取oph从表详情
* @param {Id}
*/
export function getOutputSlave(id) {
  return request({
    url: 'accounting/OutputSlave/' + id,
    method: 'get'
  })
}

/**
* 删除oph从表
* @param {主键} pid
*/
export function delOutputSlave(pid) {
  return request({
    url: 'accounting/OutputSlave/delete/' + pid,
    method: 'delete'
  })
}
// 导出oph从表
export async function exportOutputSlave(query) {
  await downFile('accounting/OutputSlave/export', { ...query })
}
