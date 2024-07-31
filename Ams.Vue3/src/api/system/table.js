import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 表名称分页查询
 * @param {查询条件} data
 */
export function listSysTable(query) {
  return request({
    url: 'system/table/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增表名称
 * @param data
 */
export function addSysTable(data) {
  return request({
    url: 'system/table',
    method: 'post',
    data: data,
  })
}
/**
 * 修改表名称
 * @param data
 */
export function updateSysTable(data) {
  return request({
    url: 'system/table',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取表名称详情
 * @param {Id}
 */
export function getSysTable(id) {
  return request({
    url: 'system/table/' + id,
    method: 'get'
  })
}

/**
 * 删除表名称
 * @param {主键} pid
 */
export function delSysTable(pid) {
  return request({
    url: 'system/table/delete/' + pid,
    method: 'delete'
  })
}
// 导出表名称
export async function exportSysTable(query) {
  await downFile('system/table/export', { ...query })
}
