import request from '@/utils/request'
import QS from 'qs'
import { downFile } from '@/utils/request'

/**
 * 制一OPH从表分页查询
 * @param {查询条件} data
 */
export function listPpOutputAssySlave(query) {
  return request({
    url: 'Logistics/PpOutputAssySlave/list',
    method: 'get',
    params: query,
    paramsSerializer: function (params) {
      return QS.stringify(params, { indices: false })
    }
  })
}

/**
 * 新增制一OPH从表
 * @param data
 */
export function addPpOutputAssySlave(data) {
  return request({
    url: 'Logistics/PpOutputAssySlave',
    method: 'post',
    data: data,
  })
}
/**
 * 修改制一OPH从表
 * @param data
 */
export function updatePpOutputAssySlave(data) {
  return request({
    url: 'Logistics/PpOutputAssySlave',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取制一OPH从表详情
 * @param {Id}
 */
export function getPpOutputAssySlave(id) {
  return request({
    url: 'Logistics/PpOutputAssySlave/' + id,
    method: 'get'
  })
}

/**
 * 删除制一OPH从表
 * @param {主键} pid
 */
export function delPpOutputAssySlave(pid) {
  return request({
    url: 'Logistics/PpOutputAssySlave/delete/' + pid,
    method: 'delete'
  })
}
// 导出制一OPH从表
export async function exportPpOutputAssySlave(query) {
  await downFile('Logistics/PpOutputAssySlave/export', { ...query })
}
