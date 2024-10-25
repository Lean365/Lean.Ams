import request from '@/utils/request'
/**
* 查询当月生产台数
* @param query
*/
export function getMonthlyOutputQty(query) {
  return request({
    url: 'stat/output/MonthlyOutputQty',
    method: 'get',
    params: query,
  })
}
/**
* 按月统计OPH
* @param query
*/
export function getListMonthOutput(query) {
  return request({
    url: 'stat/output/ListMonthOutput',
    method: 'get',
    params: query,
  })
}
/**
* 按月统计OPH导出
* @param query
*/
export function getExportMonthOutput(query) {
  return request({
    url: 'stat/output/ExportMonthOutput',
    method: 'get',
    params: query,
  })
}
/**
* 按月,班组统计OPH
* @param query
*/
export function getListMonthLineOutput(query) {
  return request({
    url: 'stat/output/ListMonthLineOutput',
    method: 'get',
    params: query,
  })
}
/**
* 按月,班组统计OPH Bar
* @param query
*/
export function getListMonthLineOutputBar(query) {
  return request({
    url: 'stat/output/ListMonthLineOutputBar',
    method: 'get',
    params: query,
  })
}

/**
* 当月,班组统计OPH Bar
* @param query
*/
export function getListCurrentMonthLineOutputBar(query) {
  return request({
    url: 'stat/output/ListCurrentMonthLineOutputBar',
    method: 'get',
    params: query,
  })
}
/**
* 按月班组统计OPH导出
* @param query
*/
export function getExportMonthLineOutputList(query) {
  return request({
    url: 'stat/output/ExportMonthLineOutputList',
    method: 'get',
    params: query,
  })
}
/**
* 按月，机种统计OPH
* @param query
*/
export function getListMonthModelOutput(query) {
  return request({
    url: 'stat/output/ListMonthModelOutput',
    method: 'get',
    params: query,
  })
}
/**
* 按月机种统计OPH导出
* @param query
*/
export function getExportMonthModelOutputList(query) {
  return request({
    url: 'stat/output/ExportMonthModelOutputList',
    method: 'get',
    params: query,
  })
}


