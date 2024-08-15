import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 数据表字段分页查询
 * @param {查询条件} data
 */
export function listSysTableFields(query) {
  return request({
    url: 'system/table/fields/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增数据表字段
 * @param data
 */
export function addSysTableFields(data) {
  return request({
    url: 'system/table/fields',
    method: 'post',
    data: data,
  })
}
/**
 * 修改数据表字段
 * @param data
 */
export function updateSysTableFields(data) {
  return request({
    url: 'system/table/fields',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取数据表字段详情
 * @param {Id}
 */
export function getSysTableFields(id) {
  return request({
    url: 'system/table/fields/' + id,
    method: 'get'
  })
}

/**
 * 删除数据表字段
 * @param {主键} pid
 */
export function delSysTableFields(pid) {
  return request({
    url: 'system/table/fields/delete/' + pid,
    method: 'delete'
  })
}
// 导出数据表字段
export async function exportSysTableFields(query) {
  await downFile('system/table/fields/export', { ...query })
}
