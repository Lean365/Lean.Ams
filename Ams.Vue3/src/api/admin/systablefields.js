import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 表字段分页查询
 * @param {查询条件} data
 */
export function listSysTableFields(query) {
  return request({
    url: 'Admin/SysTableFields/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增表字段
 * @param data
 */
export function addSysTableFields(data) {
  return request({
    url: 'Admin/SysTableFields',
    method: 'post',
    data: data,
  })
}
/**
 * 修改表字段
 * @param data
 */
export function updateSysTableFields(data) {
  return request({
    url: 'Admin/SysTableFields',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取表字段详情
 * @param {Id}
 */
export function getSysTableFields(id) {
  return request({
    url: 'Admin/SysTableFields/' + id,
    method: 'get'
  })
}

/**
 * 删除表字段
 * @param {主键} pid
 */
export function delSysTableFields(pid) {
  return request({
    url: 'Admin/SysTableFields/delete/' + pid,
    method: 'delete'
  })
}
// 导出表字段
export async function exportSysTableFields(query) {
  await downFile('Admin/SysTableFields/export', { ...query })
}
