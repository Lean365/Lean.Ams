import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * PO残清单分页查询
 * @param {查询条件} data
 */
export function listMmPoResidue(query) {
  return request({
    url: 'Logistics/MmPoResidue/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增PO残清单
 * @param data
 */
export function addMmPoResidue(data) {
  return request({
    url: 'Logistics/MmPoResidue',
    method: 'post',
    data: data,
  })
}
/**
 * 修改PO残清单
 * @param data
 */
export function updateMmPoResidue(data) {
  return request({
    url: 'Logistics/MmPoResidue',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取PO残清单详情
 * @param {Id}
 */
export function getMmPoResidue(id) {
  return request({
    url: 'Logistics/MmPoResidue/' + id,
    method: 'get'
  })
}

/**
 * 删除PO残清单
 * @param {主键} pid
 */
export function delMmPoResidue(pid) {
  return request({
    url: 'Logistics/MmPoResidue/delete/' + pid,
    method: 'delete'
  })
}
// 导出PO残清单
export async function exportMmPoResidue(query) {
  await downFile('Logistics/MmPoResidue/export', { ...query })
}
