import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 物料信息分页查询
* @param {查询条件} data
*/
export function listMarb(query) {
  return request({
    url: 'logistics/Marb/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增物料信息
* @param data
*/
export function addMarb(data) {
  return request({
    url: 'logistics/Marb',
    method: 'post',
    data: data,
  })
}
/**
* 修改物料信息
* @param data
*/
export function updateMarb(data) {
  return request({
    url: 'logistics/Marb',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取物料信息详情
* @param {Id}
*/
export function getMarb(id) {
  return request({
    url: 'logistics/Marb/' + id,
    method: 'get'
  })
}

/**
* 删除物料信息
* @param {主键} pid
*/
export function delMarb(pid) {
  return request({
    url: 'logistics/Marb/delete/' + pid,
    method: 'delete'
  })
}
// 导出物料信息
export async function exportMarb(query) {
  await downFile('logistics/Marb/export', { ...query })
}
