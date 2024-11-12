import request from '@/utils/request'
/**
* 本月组立不良台数
* @param query
*/
export function getMonthlyPoorQty(query) {
  return request({
    url: 'stat/poor/assy/MonthlyPoorQty',
    method: 'get',
    params: query,
  })
}
/**
* 按月统计组立不良报表
* @param query
*/
export function getListMonthPoor(query) {
  return request({
    url: 'stat/poor/assy/ListMonthPoor',
    method: 'get',
    params: query,
  })
}
/**
* 导出月度组立不良报表
* @param query
*/
export function getExportListMonthPoor(query) {
  return request({
    url: 'stat/poor/assy/ExportListMonthPoor',
    method: 'get',
    params: query,
  })
}

/**
* 按月统计组立不良--柱状图
* @param query
*/
export function getListMonthlyPoorBar(query) {
  return request({
    url: 'stat/poor/assy/ListMonthlyPoorBar',
    method: 'get',
    params: query,
  })
}



