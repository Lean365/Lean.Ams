import request from '@/utils/request'
/**
* 根据类型生成订单号
* @param query
*/

export function getMonthlyProdCost(query) {
  return request({
    url: 'stat/comparison/MonthlyProdCost',
    method: 'get',
    params: query,
  })
}

