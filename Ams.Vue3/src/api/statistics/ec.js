import request from '@/utils/request'
/**
 * ec点数统计
* @param query
*/
export function getEcCount(query) {
  return request({
    url: 'stat/ec/EcCount',
    method: 'get',
    params: query,
  })
}
/**
 * 按月统计ec点数
* @param query
*/
export function getMonthlyEcCount(query) {
  return request({
    url: 'stat/ec/MonthlyEcCount',
    method: 'get',
    params: query,
  })
}
/**
 * 按月统计ec点数Bar
* @param query
*/
export function getMonthlyEcBar(query) {
  return request({
    url: 'stat/ec/MonthlyEcBar',
    method: 'get',
    params: query,
  })
}
