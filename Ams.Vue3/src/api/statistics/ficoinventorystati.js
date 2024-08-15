import request from '@/utils/request'
/**
* 根据类型生成订单号
* @param query
*/

export function getMonthlyInventoryAmount(query) {
  return request({
    url: 'stat/inventory/MonthlyInventoryAmount',
    method: 'get',
    params: query,
  })
}

