import request from '@/utils/request'
/**
* 根据类型生成订单号
* @param query
*/
export function getNewOrderNum(query) {
  return request({
    url: 'stat/order/NewOrderNumber',
    method: 'get',
    params: query,
  })
}
