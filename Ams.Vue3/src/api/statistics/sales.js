import request from '@/utils/request'
/**
* 查询当月销售台数
* @param query
*/

export function getCurrentMonthSalesQty(query) {
  return request({
    url: 'stat/sales/CurrentMonthSalesQty',
    method: 'get',
    params: query,
  })
}
/*
* 查询当月销售额
* @param query
*/
export function getCurrentMonthSalesAmount(query) {
  return request({
    url: 'stat/sales/CurrentMonthSalesAmount',
    method: 'get',
    params: query,
  })
}
/*
* 按月统计销售
* @param query
*/
export function getMonthlySales(query) {
  return request({
    url: 'stat/sales/MonthlySales',
    method: 'get',
    params: query,
  })
}
/*
* 按月,国家统计销售
* @param query
*/
export function getMonthlyAreaSales(query) {
  return request({
    url: 'stat/sales/MonthlyAreaSales',
    method: 'get',
    params: query,
  })
}
/*
* 按月,仕向统计销售
* @param query
*/
export function getMonthlyRegionSales(query) {
  return request({
    url: 'stat/sales/MonthlyRegionSales',
    method: 'get',
    params: query,
  })
}
/*
* 按年统计销售
* @param query
*/
export function getYearSales(query) {
  return request({
    url: 'stat/sales/YearSales',
    method: 'get',
    params: query,
  })
}
/*
* 按年统计销售-国家
* @param query
*/
export function getYearAreaSales(query) {
  return request({
    url: 'stat/sales/YearAreaSales',
    method: 'get',
    params: query,
  })
}
/*
* 按年统计销售-仕向
* @param query
*/
export function getYearRegionSales(query) {
  return request({
    url: 'stat/sales/YearRegionSales',
    method: 'get',
    params: query,
  })
}
/*
* 按月统计销售--柱状图
* @param query
*/
export function getListMonthlySalesBar(query) {
  return request({
    url: 'stat/sales/ListMonthlySalesBar',
    method: 'get',
    params: query,
  })
}