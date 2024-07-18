import request from '@/utils/request'
/**
* 根据类型生成订单号
* @param query
*/
export function getMonthlyOutputQty(query) {
  return request({
    url: 'stat/output/MonthlyOutputQty',
    method: 'get',
    params: query,
  })
}
