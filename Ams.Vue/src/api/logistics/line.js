import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 生产班组分页查询
* @param {查询条件} data
*/
export function listLine(query) {
  return request({
    url: 'logistics/Line/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增生产班组
* @param data
*/
export function addLine(data) {
  return request({
    url: 'logistics/Line',
    method: 'post',
    data: data,
  })
}
/**
* 修改生产班组
* @param data
*/
export function updateLine(data) {
  return request({
    url: 'logistics/Line',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取生产班组详情
* @param {Id}
*/
export function getLine(id) {
  return request({
    url: 'logistics/Line/' + id,
    method: 'get'
  })
}

/**
* 删除生产班组
* @param {主键} pid
*/
export function delLine(pid) {
  return request({
    url: 'logistics/Line/delete/' + pid,
    method: 'delete'
  })
}
// 导出生产班组
export async function exportLine(query) {
  await downFile('logistics/Line/export', { ...query })
}
