import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 修理日报slv分页查询
 * @param {查询条件} data
 */
export function listPpRepairPcbaSlv(query) {
  return request({
    url: 'Logistics/PpRepairPcbaSlv/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增修理日报slv
 * @param data
 */
export function addPpRepairPcbaSlv(data) {
  return request({
    url: 'Logistics/PpRepairPcbaSlv',
    method: 'post',
    data: data,
  })
}
/**
 * 修改修理日报slv
 * @param data
 */
export function updatePpRepairPcbaSlv(data) {
  return request({
    url: 'Logistics/PpRepairPcbaSlv',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取修理日报slv详情
 * @param {Id}
 */
export function getPpRepairPcbaSlv(id) {
  return request({
    url: 'Logistics/PpRepairPcbaSlv/' + id,
    method: 'get'
  })
}

/**
 * 删除修理日报slv
 * @param {主键} pid
 */
export function delPpRepairPcbaSlv(pid) {
  return request({
    url: 'Logistics/PpRepairPcbaSlv/delete/' + pid,
    method: 'delete'
  })
}
// 导出修理日报slv
export async function exportPpRepairPcbaSlv(query) {
  await downFile('Logistics/PpRepairPcbaSlv/export', { ...query })
}
