import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 生产工单分页查询
 * @param {查询条件} data
 */
export function listPpMasterProdorder(query) {
  return request({
    url: 'Logistics/PpMasterProdorder/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增生产工单
 * @param data
 */
export function addPpMasterProdorder(data) {
  return request({
    url: 'Logistics/PpMasterProdorder',
    method: 'post',
    data: data,
  })
}
/**
 * 修改生产工单
 * @param data
 */
export function updatePpMasterProdorder(data) {
  return request({
    url: 'Logistics/PpMasterProdorder',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取生产工单详情
 * @param {Id}
 */
export function getPpMasterProdorder(id) {
  return request({
    url: 'Logistics/PpMasterProdorder/' + id,
    method: 'get'
  })
}

/**
 * 删除生产工单
 * @param {主键} pid
 */
export function delPpMasterProdorder(pid) {
  return request({
    url: 'Logistics/PpMasterProdorder/delete/' + pid,
    method: 'delete'
  })
}
// 导出生产工单
export async function exportPpMasterProdorder(query) {
  await downFile('Logistics/PpMasterProdorder/export', { ...query })
}
