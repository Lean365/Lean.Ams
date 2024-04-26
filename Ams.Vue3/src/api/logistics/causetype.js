import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 原因类别分页查询
* @param {查询条件} data
*/
export function listCauseType(query) {
  return request({
    url: 'logistics/CauseType/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增原因类别
* @param data
*/
export function addCauseType(data) {
  return request({
    url: 'logistics/CauseType',
    method: 'post',
    data: data,
  })
}
/**
* 修改原因类别
* @param data
*/
export function updateCauseType(data) {
  return request({
    url: 'logistics/CauseType',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取原因类别详情
* @param {Id}
*/
export function getCauseType(id) {
  return request({
    url: 'logistics/CauseType/' + id,
    method: 'get'
  })
}

/**
* 删除原因类别
* @param {主键} pid
*/
export function delCauseType(pid) {
  return request({
    url: 'logistics/CauseType/delete/' + pid,
    method: 'delete'
  })
}
// 导出原因类别
export async function exportCauseType(query) {
  await downFile('logistics/CauseType/export', { ...query })
}
