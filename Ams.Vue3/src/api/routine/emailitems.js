import request from '@/utils/request'

/**
* 邮件发送记录分页查询
* @param {查询条件} data
*/
export function listEmailItems(query) {
  return request({
    url: 'routine/email/items/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增邮件发送记录
* @param data
*/
export function sendEmail(data) {
  return request({
    url: 'routine/email/items/sendEmail',
    method: 'post',
    data: data,
  })
}
/**
* 获取邮件发送记录详情
* @param {Id}
*/
export function getEmailItems(id) {
  return request({
    url: 'routine/email/items/' + id,
    method: 'get'
  })
}

/**
* 删除邮件发送记录
* @param {主键} pid
*/
export function delEmailItems(pid) {
  return request({
    url: 'routine/email/items/' + pid,
    method: 'delete'
  })
}
