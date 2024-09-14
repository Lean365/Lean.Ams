import request from '@/utils/request'
import QS from 'qs'
import { downFile } from '@/utils/request'

/**
 * 组立明细分页查询
 * @param {查询条件} data
 */
export function listPpOutputAssySlv(query) {
  return request({
    url: 'Logistics/PpOutputAssySlv/list',
    method: 'get',
    params: query,
    paramsSerializer: function (params) {
      return QS.stringify(params, { indices: false })
    }
  })
}

/**
 * 新增组立明细
 * @param data
 */
export function addPpOutputAssySlv(data) {
  return request({
    url: 'Logistics/PpOutputAssySlv',
    method: 'post',
    data: data,
  })
}
/**
 * 修改组立明细
 * @param data
 */
export function updatePpOutputAssySlv(data) {
  return request({
    url: 'Logistics/PpOutputAssySlv',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取组立明细详情
 * @param {Id}
 */
export function getPpOutputAssySlv(id) {
  return request({
    url: 'Logistics/PpOutputAssySlv/' + id,
    method: 'get'
  })
}

/**
 * 删除组立明细
 * @param {主键} pid
 */
export function delPpOutputAssySlv(pid) {
  return request({
    url: 'Logistics/PpOutputAssySlv/delete/' + pid,
    method: 'delete'
  })
}
// 导出组立明细
export async function exportPpOutputAssySlv(query) {
  await downFile('Logistics/PpOutputAssySlv/export', { ...query })
}
