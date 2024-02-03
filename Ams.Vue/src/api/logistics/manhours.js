import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 标准工时分页查询
* @param {查询条件} data
*/
export function listManhours(query) {
  return request({
    url: 'logistics/Manhours/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增标准工时
* @param data
*/
export function addManhours(data) {
  return request({
    url: 'logistics/Manhours',
    method: 'post',
    data: data,
  })
}
/**
* 修改标准工时
* @param data
*/
export function updateManhours(data) {
  return request({
    url: 'logistics/Manhours',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取标准工时详情
* @param {Id}
*/
export function getManhours(id) {
  return request({
    url: 'logistics/Manhours/' + id,
    method: 'get'
  })
}

/**
* 删除标准工时
* @param {主键} pid
*/
export function delManhours(pid) {
  return request({
    url: 'logistics/Manhours/delete/' + pid,
    method: 'delete'
  })
}
// 导出标准工时
export async function exportManhours(query) {
  await downFile('logistics/Manhours/export', { ...query })
}
