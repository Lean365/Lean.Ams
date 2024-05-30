import request from '@/utils/request'
import QS from 'qs'
import { downFile } from '@/utils/request'

/**
* oph从表分页查询
* @param {查询条件} data
*/
export function listPpOutputSlave(query) {
  return request({
    url: 'logistics/PpOutputSlave/list',
    method: 'get',
    params: query,
    paramsSerializer: function (params) {
      return QS.stringify(params, { indices: false })
    }
  })
}

/**
* 新增oph从表
* @param data
*/
export function addPpOutputSlave(data) {
  return request({
    url: 'logistics/PpOutputSlave',
    method: 'post',
    data: data,
  })
}
/**
* 修改oph从表
* @param data
*/
export function updatePpOutputSlave(data) {
  return request({
    url: 'logistics/PpOutputSlave',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取oph从表详情
* @param {Id}
*/
export function getPpOutputSlave(id) {
  return request({
    url: 'logistics/PpOutputSlave/' + id,
    method: 'get'
  })
}

/**
* 删除oph从表
* @param {主键} pid
*/
export function delPpOutputSlave(pid) {
  return request({
    url: 'logistics/PpOutputSlave/delete/' + pid,
    method: 'delete'
  })
}
// 导出oph从表
export async function exportPpOutputSlave(query) {
  await downFile('logistics/PpOutputSlave/export', { ...query })
}
