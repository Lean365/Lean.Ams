import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 工厂代码分页查询
 * @param {查询条件} data
 */
export function listInstPlant(query) {
  return request({
    url: 'Routine/InstPlant/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增工厂代码
 * @param data
 */
export function addInstPlant(data) {
  return request({
    url: 'Routine/InstPlant',
    method: 'post',
    data: data,
  })
}
/**
 * 修改工厂代码
 * @param data
 */
export function updateInstPlant(data) {
  return request({
    url: 'Routine/InstPlant',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取工厂代码详情
 * @param {Id}
 */
export function getInstPlant(id) {
  return request({
    url: 'Routine/InstPlant/' + id,
    method: 'get'
  })
}

/**
 * 删除工厂代码
 * @param {主键} pid
 */
export function delInstPlant(pid) {
  return request({
    url: 'Routine/InstPlant/delete/' + pid,
    method: 'delete'
  })
}
// 导出工厂代码
export async function exportInstPlant(query) {
  await downFile('Routine/InstPlant/export', { ...query })
}
