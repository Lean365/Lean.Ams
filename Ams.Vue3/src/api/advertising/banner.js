import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 广告管理分页查询
* @param {查询条件} data
*/
export function listBanner(query) {
  return request({
    url: 'advertising/banner/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增广告管理
* @param data
*/
export function addBanner(data) {
  return request({
    url: 'advertising/banner',
    method: 'post',
    data: data,
  })
}
/**
* 修改广告管理
* @param data
*/
export function updateBanner(data) {
  return request({
    url: 'advertising/banner',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取广告管理详情
* @param {Id}
*/
export function getBanner(id) {
  return request({
    url: 'advertising/banner/' + id,
    method: 'get'
  })
}

/**
* 删除广告管理
* @param {主键} pid
*/
export function delBanner(pid) {
  return request({
    url: 'advertising/banner/delete/' + pid,
    method: 'delete'
  })
}
// 导出广告管理
export async function exportBanner(query) {
  await downFile('advertising/banner/export', { ...query })
}
export function changeSort(data) {
  return request({
    url: 'advertising/banner/ChangeSort',
    method: 'get',
    params: data
  })
}
