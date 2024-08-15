import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 检查日报slv分页查询
 * @param {查询条件} data
 */
export function listPpInspPcbaSlv(query) {
  return request({
    url: 'Logistics/PpInspPcbaSlv/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增检查日报slv
 * @param data
 */
export function addPpInspPcbaSlv(data) {
  return request({
    url: 'Logistics/PpInspPcbaSlv',
    method: 'post',
    data: data,
  })
}
/**
 * 修改检查日报slv
 * @param data
 */
export function updatePpInspPcbaSlv(data) {
  return request({
    url: 'Logistics/PpInspPcbaSlv',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取检查日报slv详情
 * @param {Id}
 */
export function getPpInspPcbaSlv(id) {
  return request({
    url: 'Logistics/PpInspPcbaSlv/' + id,
    method: 'get'
  })
}

/**
 * 删除检查日报slv
 * @param {主键} pid
 */
export function delPpInspPcbaSlv(pid) {
  return request({
    url: 'Logistics/PpInspPcbaSlv/delete/' + pid,
    method: 'delete'
  })
}
// 导出检查日报slv
export async function exportPpInspPcbaSlv(query) {
  await downFile('Logistics/PpInspPcbaSlv/export', { ...query })
}
