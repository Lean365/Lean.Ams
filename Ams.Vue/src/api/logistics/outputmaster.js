import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* oph主表分页查询
* @param {查询条件} data
*/
export function listOutputMaster(query) {
  return request({
    url: 'logistics/OutputMaster/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增oph主表
* @param data
*/
export function addOutputMaster(data) {
  return request({
    url: 'logistics/OutputMaster',
    method: 'post',
    data: data,
  })
}
/**
* 修改oph主表
* @param data
*/
export function updateOutputMaster(data) {
  return request({
    url: 'logistics/OutputMaster',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取oph主表详情
* @param {Id}
*/
export function getOutputMaster(id) {
  return request({
    url: 'logistics/OutputMaster/' + id,
    method: 'get'
  })
}

/**
* 删除oph主表
* @param {主键} pid
*/
export function delOutputMaster(pid) {
  return request({
    url: 'logistics/OutputMaster/delete/' + pid,
    method: 'delete'
  })
}
// 导出oph主表
export async function exportOutputMaster(query) {
  await downFile('logistics/OutputMaster/export', { ...query })
}
