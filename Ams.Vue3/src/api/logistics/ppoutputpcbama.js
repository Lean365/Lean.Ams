import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * PCBA OPH分页查询
 * @param {查询条件} data
 */
export function listPpOutputPcbaMa(query) {
  return request({
    url: 'Logistics/PpOutputPcbaMa/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增PCBA OPH
 * @param data
 */
export function addPpOutputPcbaMa(data) {
  return request({
    url: 'Logistics/PpOutputPcbaMa',
    method: 'post',
    data: data,
  })
}
/**
 * 修改PCBA OPH
 * @param data
 */
export function updatePpOutputPcbaMa(data) {
  return request({
    url: 'Logistics/PpOutputPcbaMa',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取PCBA OPH详情
 * @param {Id}
 */
export function getPpOutputPcbaMa(id) {
  return request({
    url: 'Logistics/PpOutputPcbaMa/' + id,
    method: 'get'
  })
}

/**
 * 删除PCBA OPH
 * @param {主键} pid
 */
export function delPpOutputPcbaMa(pid) {
  return request({
    url: 'Logistics/PpOutputPcbaMa/delete/' + pid,
    method: 'delete'
  })
}
// 导出PCBA OPH
export async function exportPpOutputPcbaMa(query) {
  await downFile('Logistics/PpOutputPcbaMa/export', { ...query })
}
