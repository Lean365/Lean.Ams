import request from '@/utils/request'
/**
* 根据类型生成订单号
* @param query
*/
export function getEcCount(query) {
  return request({
    url: 'stat/ec/totalStati',
    method: 'get',
    params: query,
  })
}
