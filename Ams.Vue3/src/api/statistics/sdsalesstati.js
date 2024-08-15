import request from '@/utils/request'
/**
* 根据类型生成订单号
* @param query
*/

export function getMonthlySalesQty(query) {
  return request({
    url: 'stat/sales/MonthlySalesQty',
    method: 'get',
    params: query,
  })
}

export function getMonthlySalesAmount(query) {
  return request({
    url: 'stat/sales/MonthlySalesAmount',
    method: 'get',
    params: query,
  })
}
