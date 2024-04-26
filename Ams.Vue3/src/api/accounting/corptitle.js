import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 公司科目分页查询
* @param {查询条件} data
*/
export function listCorpTitle(query) {
  return request({
    url: 'accounting/CorpTitle/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增公司科目
* @param data
*/
export function addCorpTitle(data) {
  return request({
    url: 'accounting/CorpTitle',
    method: 'post',
    data: data,
  })
}
/**
* 修改公司科目
* @param data
*/
export function updateCorpTitle(data) {
  return request({
    url: 'accounting/CorpTitle',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取公司科目详情
* @param {Id}
*/
export function getCorpTitle(id) {
  return request({
    url: 'accounting/CorpTitle/' + id,
    method: 'get'
  })
}

/**
* 删除公司科目
* @param {主键} pid
*/
export function delCorpTitle(pid) {
  return request({
    url: 'accounting/CorpTitle/delete/' + pid,
    method: 'delete'
  })
}
// 导出公司科目
export async function exportCorpTitle(query) {
  await downFile('accounting/CorpTitle/export', { ...query })
}
