import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 源机种仕向分页查询
 * @param {查询条件} data
 */
export function listPpSourceModelRegion(query) {
  return request({
    url: 'Logistics/PpSourceModelRegion/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增源机种仕向
 * @param data
 */
export function addPpSourceModelRegion(data) {
  return request({
    url: 'Logistics/PpSourceModelRegion',
    method: 'post',
    data: data,
  })
}
/**
 * 修改源机种仕向
 * @param data
 */
export function updatePpSourceModelRegion(data) {
  return request({
    url: 'Logistics/PpSourceModelRegion',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取源机种仕向详情
 * @param {Id}
 */
export function getPpSourceModelRegion(id) {
  return request({
    url: 'Logistics/PpSourceModelRegion/' + id,
    method: 'get'
  })
}

/**
 * 删除源机种仕向
 * @param {主键} pid
 */
export function delPpSourceModelRegion(pid) {
  return request({
    url: 'Logistics/PpSourceModelRegion/delete/' + pid,
    method: 'delete'
  })
}
// 导出源机种仕向
export async function exportPpSourceModelRegion(query) {
  await downFile('Logistics/PpSourceModelRegion/export', { ...query })
}
