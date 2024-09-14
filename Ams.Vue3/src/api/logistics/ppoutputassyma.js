import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 组立OPH分页查询
 * @param {查询条件} data
 */
export function listPpOutputAssyMa(query) {
  return request({
    url: 'Logistics/PpOutputAssyMa/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增组立OPH
 * @param data
 */
export function addPpOutputAssyMa(data) {
  return request({
    url: 'Logistics/PpOutputAssyMa',
    method: 'post',
    data: data,
  })
}
/**
 * 修改组立OPH
 * @param data
 */
export function updatePpOutputAssyMa(data) {
  return request({
    url: 'Logistics/PpOutputAssyMa',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取组立OPH详情
 * @param {Id}
 */
export function getPpOutputAssyMa(id) {
  return request({
    url: 'Logistics/PpOutputAssyMa/' + id,
    method: 'get'
  })
}

/**
 * 删除组立OPH
 * @param {主键} pid
 */
export function delPpOutputAssyMa(pid) {
  return request({
    url: 'Logistics/PpOutputAssyMa/delete/' + pid,
    method: 'delete'
  })
}
// 导出组立OPH
export async function exportPpOutputAssyMa(query) {
  await downFile('Logistics/PpOutputAssyMa/export', { ...query })
}
