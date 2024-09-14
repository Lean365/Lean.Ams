import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 抽样标准分页查询
 * @param {查询条件} data
 */
export function listQmInspAql(query) {
  return request({
    url: 'Logistics/QmInspAql/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增抽样标准
 * @param data
 */
export function addQmInspAql(data) {
  return request({
    url: 'Logistics/QmInspAql',
    method: 'post',
    data: data,
  })
}
/**
 * 修改抽样标准
 * @param data
 */
export function updateQmInspAql(data) {
  return request({
    url: 'Logistics/QmInspAql',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取抽样标准详情
 * @param {Id}
 */
export function getQmInspAql(id) {
  return request({
    url: 'Logistics/QmInspAql/' + id,
    method: 'get'
  })
}

/**
 * 删除抽样标准
 * @param {主键} pid
 */
export function delQmInspAql(pid) {
  return request({
    url: 'Logistics/QmInspAql/delete/' + pid,
    method: 'delete'
  })
}
// 导出抽样标准
export async function exportQmInspAql(query) {
  await downFile('Logistics/QmInspAql/export', { ...query })
}
