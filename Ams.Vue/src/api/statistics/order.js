import request from '@/utils/request'
/**
* 根据类型生成订单号
* @param query
*/
export function getOrderNum(query) {
  return request({
    url: 'stat/order/OrderNum',
    method: 'get',
    params: query,
  })
}
