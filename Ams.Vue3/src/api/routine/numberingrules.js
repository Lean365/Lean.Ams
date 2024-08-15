import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 单据编码分页查询
 * @param {查询条件} data
 */
export function listNumberingRules(query) {
  return request({
    url: 'Routine/NumberingRules/list',
    method: 'get',
    params: query,
  })
}

/**
 * 新增单据编码
 * @param data
 */
export function addNumberingRules(data) {
  return request({
    url: 'Routine/NumberingRules',
    method: 'post',
    data: data,
  })
}
/**
 * 修改单据编码
 * @param data
 */
export function updateNumberingRules(data) {
  return request({
    url: 'Routine/NumberingRules',
    method: 'PUT',
    data: data,
  })
}
/**
 * 获取单据编码详情
 * @param {Id}
 */
export function getNumberingRules(id) {
  return request({
    url: 'Routine/NumberingRules/' + id,
    method: 'get'
  })
}

/**
 * 删除单据编码
 * @param {主键} pid
 */
export function delNumberingRules(pid) {
  return request({
    url: 'Routine/NumberingRules/delete/' + pid,
    method: 'delete'
  })
}
// 导出单据编码
export async function exportNumberingRules(query) {
  await downFile('Routine/NumberingRules/export', { ...query })
}
