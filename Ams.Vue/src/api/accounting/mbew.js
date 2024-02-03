import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 物料评估分页查询
* @param {查询条件} data
*/
export function listMbew(query) {
  return request({
    url: 'accounting/Mbew/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增物料评估
* @param data
*/
export function addMbew(data) {
  return request({
    url: 'accounting/Mbew',
    method: 'post',
    data: data,
  })
}
/**
* 修改物料评估
* @param data
*/
export function updateMbew(data) {
  return request({
    url: 'accounting/Mbew',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取物料评估详情
* @param {Id}
*/
export function getMbew(id) {
  return request({
    url: 'accounting/Mbew/' + id,
    method: 'get'
  })
}

/**
* 删除物料评估
* @param {主键} pid
*/
export function delMbew(pid) {
  return request({
    url: 'accounting/Mbew/delete/' + pid,
    method: 'delete'
  })
}
// 导出物料评估
export async function exportMbew(query) {
  await downFile('accounting/Mbew/export', { ...query })
}
