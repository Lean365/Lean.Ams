import request from '@/utils/request'
/**
* 根据类型生成订单号
* @param query
*/

export function getMonthlyProductionCost(query) {
  return request({
    url: 'stat/cost/MonthlyProductionCost',
    method: 'get',
    params: query,
  })
}

