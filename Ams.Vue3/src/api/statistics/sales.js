import request from '@/utils/request'
//获取当月销售数据（台数/金额）
export function getCurrentMonthlySales(query) {
  return request({
    url: 'stat/sales/CurrentMonthlySales',
    method: 'get',
    params: query,
  })
}