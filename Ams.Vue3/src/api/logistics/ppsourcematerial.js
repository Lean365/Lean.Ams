import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 源物料分页查询
 * @param {查询条件} data
 */
export function listPpSourceMaterial(query) {
  return request({
    url: 'Logistics/PpSourceMaterial/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增源物料
 * @param data
 */
export function addPpSourceMaterial(data) {
  return request({
    url: 'Logistics/PpSourceMaterial',
    method: 'post',
    data: data,
  })
}
/**
 * 修改源物料
 * @param data
 */
export function updatePpSourceMaterial(data) {
  return request({
    url: 'Logistics/PpSourceMaterial',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取源物料详情
 * @param {Id}
 */
export function getPpSourceMaterial(id) {
  return request({
    url: 'Logistics/PpSourceMaterial/' + id,
    method: 'get'
  })
}

/**
 * 删除源物料
 * @param {主键} pid
 */
export function delPpSourceMaterial(pid) {
  return request({
    url: 'Logistics/PpSourceMaterial/delete/' + pid,
    method: 'delete'
  })
}
// 导出源物料
export async function exportPpSourceMaterial(query) {
  await downFile('Logistics/PpSourceMaterial/export', { ...query })
}
