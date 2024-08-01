import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 采购分页查询
 * @param {查询条件} data
 */
export function listPpEcMasterPur(query) {
  return request({
    url: 'Logistics/PpEcMasterPur/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增采购
 * @param data
 */
export function addPpEcMasterPur(data) {
  return request({
    url: 'Logistics/PpEcMasterPur',
    method: 'post',
    data: data,
  })
}
/**
 * 修改采购
 * @param data
 */
export function updatePpEcMasterPur(data) {
  return request({
    url: 'Logistics/PpEcMasterPur',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取采购详情
 * @param {Id}
 */
export function getPpEcMasterPur(id) {
  return request({
    url: 'Logistics/PpEcMasterPur/' + id,
    method: 'get'
  })
}

/**
 * 删除采购
 * @param {主键} pid
 */
export function delPpEcMasterPur(pid) {
  return request({
    url: 'Logistics/PpEcMasterPur/delete/' + pid,
    method: 'delete'
  })
}
// 导出采购
export async function exportPpEcMasterPur(query) {
  await downFile('Logistics/PpEcMasterPur/export', { ...query })
}
