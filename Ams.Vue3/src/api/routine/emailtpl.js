import request from '@/utils/request'

/**
* 邮件模板分页查询
* @param {查询条件} data
*/
export function listEmailTpl(query) {
  return request({
    url: 'routine/email/tpl/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增邮件模板
* @param data
*/
export function addEmailTpl(data) {
  return request({
    url: 'routine/email/tpl',
    method: 'post',
    data: data,
  })
}
/**
* 修改邮件模板
* @param data
*/
export function updateEmailTpl(data) {
  return request({
    url: 'routine/email/tpl',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取邮件模板详情
* @param {Id}
*/
export function getEmailTpl(id) {
  return request({
    url: 'routine/email/tpl/' + id,
    method: 'get'
  })
}

/**
* 删除邮件模板
* @param {主键} pid
*/
export function delEmailTpl(pid) {
  return request({
    url: 'routine/email/tpl/' + pid,
    method: 'delete'
  })
}
