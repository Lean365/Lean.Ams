import request from '@/utils/request'
/**
* 按性别生成工号
* @param query
*/
export function getMaxWorkNumber(query) {
  return request({
    url: 'stat/employee/MaxWorkNumber',
    method: 'get',
    params: query,
  })
}
