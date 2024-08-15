import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 短信验证码记录分页查询
 * @param {查询条件} data
 */
export function listSmsLog(query) {
  return request({
    url: 'monitor/sms/list',
    method: 'get',
    params: query
  })
}

/**
 * 获取短信验证码记录详情
 * @param {Id}
 */
export function getSmsLog(id) {
  return request({
    url: 'monitor/sms/' + id,
    method: 'get'
  })
}

/**
 * 删除短信验证码记录
 * @param {主键} pid
 */
export function delSmsLog(pid) {
  return request({
    url: 'monitor/sms/' + pid,
    method: 'delete'
  })
}
// 导出短信验证码记录
export async function exportSmsLog(query) {
  await downFile('monitor/sms/export', { ...query })
}
