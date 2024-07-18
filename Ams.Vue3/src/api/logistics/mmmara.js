import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 常规物料分页查询
 * @param {查询条件} data
 */
export function listMmMara(query) {
  return request({
    url: 'Logistics/MmMara/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增常规物料
 * @param data
 */
export function addMmMara(data) {
  return request({
    url: 'Logistics/MmMara',
    method: 'post',
    data: data,
  })
}
/**
 * 修改常规物料
 * @param data
 */
export function updateMmMara(data) {
  return request({
    url: 'Logistics/MmMara',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取常规物料详情
 * @param {Id}
 */
export function getMmMara(id) {
  return request({
    url: 'Logistics/MmMara/' + id,
    method: 'get'
  })
}

/**
 * 删除常规物料
 * @param {主键} pid
 */
export function delMmMara(pid) {
  return request({
    url: 'Logistics/MmMara/delete/' + pid,
    method: 'delete'
  })
}
// 导出常规物料
export async function exportMmMara(query) {
  await downFile('Logistics/MmMara/export', { ...query })
}
