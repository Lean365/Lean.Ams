import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 工厂物料分页查询
 * @param {查询条件} data
 */
export function listMmMarc(query) {
  return request({
    url: 'Logistics/MmMarc/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增工厂物料
 * @param data
 */
export function addMmMarc(data) {
  return request({
    url: 'Logistics/MmMarc',
    method: 'post',
    data: data,
  })
}
/**
 * 修改工厂物料
 * @param data
 */
export function updateMmMarc(data) {
  return request({
    url: 'Logistics/MmMarc',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取工厂物料详情
 * @param {Id}
 */
export function getMmMarc(id) {
  return request({
    url: 'Logistics/MmMarc/' + id,
    method: 'get'
  })
}

/**
 * 删除工厂物料
 * @param {主键} pid
 */
export function delMmMarc(pid) {
  return request({
    url: 'Logistics/MmMarc/delete/' + pid,
    method: 'delete'
  })
}
// 导出工厂物料
export async function exportMmMarc(query) {
  await downFile('Logistics/MmMarc/export', { ...query })
}
