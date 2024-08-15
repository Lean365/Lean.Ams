import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 物料评估分页查询
 * @param {查询条件} data
 */
export function listMmMbew(query) {
  return request({
    url: 'Logistics/MmMbew/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增物料评估
 * @param data
 */
export function addMmMbew(data) {
  return request({
    url: 'Logistics/MmMbew',
    method: 'post',
    data: data,
  })
}
/**
 * 修改物料评估
 * @param data
 */
export function updateMmMbew(data) {
  return request({
    url: 'Logistics/MmMbew',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取物料评估详情
 * @param {Id}
 */
export function getMmMbew(id) {
  return request({
    url: 'Logistics/MmMbew/' + id,
    method: 'get'
  })
}

/**
 * 删除物料评估
 * @param {主键} pid
 */
export function delMmMbew(pid) {
  return request({
    url: 'Logistics/MmMbew/delete/' + pid,
    method: 'delete'
  })
}
// 导出物料评估
export async function exportMmMbew(query) {
  await downFile('Logistics/MmMbew/export', { ...query })
}
