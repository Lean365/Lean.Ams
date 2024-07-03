import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 公司科目分页查询
 * @param {查询条件} data
 */
export function listFicoCorpTitle(query) {
  return request({
    url: 'Accounting/FicoCorpTitle/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增公司科目
 * @param data
 */
export function addFicoCorpTitle(data) {
  return request({
    url: 'Accounting/FicoCorpTitle',
    method: 'post',
    data: data,
  })
}
/**
 * 修改公司科目
 * @param data
 */
export function updateFicoCorpTitle(data) {
  return request({
    url: 'Accounting/FicoCorpTitle',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取公司科目详情
 * @param {Id}
 */
export function getFicoCorpTitle(id) {
  return request({
    url: 'Accounting/FicoCorpTitle/' + id,
    method: 'get'
  })
}

/**
 * 删除公司科目
 * @param {主键} pid
 */
export function delFicoCorpTitle(pid) {
  return request({
    url: 'Accounting/FicoCorpTitle/delete/' + pid,
    method: 'delete'
  })
}
// 导出公司科目
export async function exportFicoCorpTitle(query) {
  await downFile('Accounting/FicoCorpTitle/export', { ...query })
}
