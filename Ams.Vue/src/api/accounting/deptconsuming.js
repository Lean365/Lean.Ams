import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 部门消耗分页查询
* @param {查询条件} data
*/
export function listDeptConsuming(query) {
  return request({
    url: 'accounting/DeptConsuming/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增部门消耗
* @param data
*/
export function addDeptConsuming(data) {
  return request({
    url: 'accounting/DeptConsuming',
    method: 'post',
    data: data,
  })
}
/**
* 修改部门消耗
* @param data
*/
export function updateDeptConsuming(data) {
  return request({
    url: 'accounting/DeptConsuming',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取部门消耗详情
* @param {Id}
*/
export function getDeptConsuming(id) {
  return request({
    url: 'accounting/DeptConsuming/' + id,
    method: 'get'
  })
}

/**
* 删除部门消耗
* @param {主键} pid
*/
export function delDeptConsuming(pid) {
  return request({
    url: 'accounting/DeptConsuming/delete/' + pid,
    method: 'delete'
  })
}
// 导出部门消耗
export async function exportDeptConsuming(query) {
  await downFile('accounting/DeptConsuming/export', { ...query })
}
