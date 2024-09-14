import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 生产班组分页查询
 * @param {查询条件} data
 */
export function listPpMasterWorkshop(query) {
  return request({
    url: 'Logistics/PpMasterWorkshop/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增生产班组
 * @param data
 */
export function addPpMasterWorkshop(data) {
  return request({
    url: 'Logistics/PpMasterWorkshop',
    method: 'post',
    data: data,
  })
}
/**
 * 修改生产班组
 * @param data
 */
export function updatePpMasterWorkshop(data) {
  return request({
    url: 'Logistics/PpMasterWorkshop',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取生产班组详情
 * @param {Id}
 */
export function getPpMasterWorkshop(id) {
  return request({
    url: 'Logistics/PpMasterWorkshop/' + id,
    method: 'get'
  })
}

/**
 * 删除生产班组
 * @param {主键} pid
 */
export function delPpMasterWorkshop(pid) {
  return request({
    url: 'Logistics/PpMasterWorkshop/delete/' + pid,
    method: 'delete'
  })
}
// 导出生产班组
export async function exportPpMasterWorkshop(query) {
  await downFile('Logistics/PpMasterWorkshop/export', { ...query })
}
