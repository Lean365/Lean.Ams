import request from '@/utils/request'
import QS from 'qs'
import { downFile } from '@/utils/request'

/**
 * 制二OPH从表分页查询
 * @param {查询条件} data
 */
export function listPpOutputPcbaSlave(query) {
  return request({
    url: 'Logistics/PpOutputPcbaSlave/list',
    method: 'get',
    params: query,
    paramsSerializer: function (params) {
      return QS.stringify(params, { indices: false })
    }
  })
}

/**
 * 新增制二OPH从表
 * @param data
 */
export function addPpOutputPcbaSlave(data) {
  return request({
    url: 'Logistics/PpOutputPcbaSlave',
    method: 'post',
    data: data,
  })
}
/**
 * 修改制二OPH从表
 * @param data
 */
export function updatePpOutputPcbaSlave(data) {
  return request({
    url: 'Logistics/PpOutputPcbaSlave',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取制二OPH从表详情
 * @param {Id}
 */
export function getPpOutputPcbaSlave(id) {
  return request({
    url: 'Logistics/PpOutputPcbaSlave/' + id,
    method: 'get'
  })
}

/**
 * 删除制二OPH从表
 * @param {主键} pid
 */
export function delPpOutputPcbaSlave(pid) {
  return request({
    url: 'Logistics/PpOutputPcbaSlave/delete/' + pid,
    method: 'delete'
  })
}
// 导出制二OPH从表
export async function exportPpOutputPcbaSlave(query) {
  await downFile('Logistics/PpOutputPcbaSlave/export', { ...query })
}
