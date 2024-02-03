import request from '@/utils/request'

//获取最大ID
export function getQuerySfid(query) {
  return request({
    url: 'stat/output/MaxSfid',
    method: 'get',
    params: query,
  })
}
//获取当月台数
export function getMonthlyProductionQty(query) {
  return request({
    url: 'stat/output/MonthlyProductionQty',
    method: 'get',
    params: query,
  })
}
//按月统计OPH
export function getCountMonthOutput(query) {
  return request({
    url: 'stat/output/CountMonthOutput',
    method: 'get',
    params: query,
  })
}
//月度OPH导出
export function getExportMonthOutput(query) {
  return request({
    url: 'stat/output/ExportMonthOutput',
    method: 'get',
    params: query,
  })
}
//按月,班组统计OPH
export function getCountMonthLineOutput(query) {
  return request({
    url: 'stat/output/CountMonthLineOutput',
    method: 'get',
    params: query,
  })
}
//按月,班组统计OPH
export function getCountMonthLineOutputBar(query) {
  return request({
    url: 'stat/output/CountMonthLineOutputBar',
    method: 'get',
    params: query,
  })
}

//当月,班组统计OPH
export function getCountCurrentMonthBar(query) {
  return request({
    url: 'stat/output/CountCurrentMonthOutputBar',
    method: 'get',
    params: query,
  })
}
//月度OPH导出班组
export function getExportMonthLineOutput(query) {
  return request({
    url: 'stat/output/ExportMonthLineOutputList',
    method: 'get',
    params: query,
  })
}
//按月，机种统计OPH
export function getCountMonthModelOutput(query) {
  return request({
    url: 'stat/output/CountMonthModelOutput',
    method: 'get',
    params: query,
  })
}
//月度OPH导出机种
export function getExportMonthModelOutput(query) {
  return request({
    url: 'stat/output/ExportMonthModelOutputList',
    method: 'get',
    params: query,
  })
}
//按月统计EC
export function getCountMonthEc(query) {
  return request({
    url: 'stat/output/CountMonthEc',
    method: 'get',
    params: query,
  })
}
//按月统计OPH不良
export function getCountMonthDefective(query) {
  return request({
    url: 'stat/output/CountMonthDefective',
    method: 'get',
    params: query,
  })
}
//按月统计OPH工数
export function getCountMonthLaborhours(query) {
  return request({
    url: 'stat/output/CountMonthLaborhours',
    method: 'get',
    params: query,
  })
}
//按月统计IQC进货
export function getCountMonthIncoming(query) {
  return request({
    url: 'stat/output/CountMonthIncoming',
    method: 'get',
    params: query,
  })
}
//按月统计QA出货
export function getCountMonthOutgoing(query) {
  return request({
    url: 'stat/output/CountMonthOutgoing',
    method: 'get',
    params: query,
  })
}
//按月统计销售
export function getCountMonthSales(query) {
  return request({
    url: 'stat/output/CountMonthSales',
    method: 'get',
    params: query,
  })
}
//按月,国家统计销售
export function getCountMonthAreaSales(query) {
  return request({
    url: 'stat/output/CountMonthAreaSales',
    method: 'get',
    params: query,
  })
}
//按月,仕向统计销售
export function getCountMonthRegionSales(query) {
  return request({
    url: 'stat/output/CountMonthRegionSales',
    method: 'get',
    params: query,
  })
}
//按年统计OPH
export function getCountYearOutput(query) {
  return request({
    url: 'stat/output/CountYearOutput',
    method: 'get',
    params: query,
  })
}
//按年导出OPH
export function getExportYearOutput(query) {
  return request({
    url: 'stat/output/ExportYearOutput',
    method: 'get',
    params: query,
  })
}
//按年班组统计OPH
export function getCountYearLineOutput(query) {
  return request({
    url: 'stat/output/CountYearLineOutput',
    method: 'get',
    params: query,
  })
}
//按年班组导出OPH
export function getExportYearLineOutput(query) {
  return request({
    url: 'stat/output/ExportYearLineOutput',
    method: 'get',
    params: query,
  })
}

//按年，机种统计OPH
export function getCountYearModelOutput(query) {
  return request({
    url: 'stat/output/CountYearModelOutput',
    method: 'get',
    params: query,
  })
}
//按年，机种导出OPH
export function getExportYearModelOutput(query) {
  return request({
    url: 'stat/output/ExportYearModelOutput',
    method: 'get',
    params: query,
  })
}
//按年统计EC
export function getCountYearEc(query) {
  return request({
    url: 'stat/output/CountYearEc',
    method: 'get',
    params: query,
  })
}
//按年统计OPH不良
export function getCountYearDefective(query) {
  return request({
    url: 'stat/output/CountYearDefective',
    method: 'get',
    params: query,
  })
}
//按年统计OPH工数
export function getCountYearLaborhours(query) {
  return request({
    url: 'stat/output/CountYearLaborhours',
    method: 'get',
    params: query,
  })
}
//按年统计IQC进货
export function getCountYearIncoming(query) {
  return request({
    url: 'stat/output/CountYearIncoming',
    method: 'get',
    params: query,
  })
}
//按年统计QA出货
export function getCountYearOutgoing(query) {
  return request({
    url: 'stat/output/CountYearOutgoing',
    method: 'get',
    params: query,
  })
}
//按年统计销售
export function getCountYearSales(query) {
  return request({
    url: 'stat/output/CountYearSales',
    method: 'get',
    params: query,
  })
}
//按年,国家统计销售
export function getCountYearAreaSales(query) {
  return request({
    url: 'stat/output/CountYearAreaSales',
    method: 'get',
    params: query,
  })
}
//按年,仕向统计销售
export function getCountYearRegionSales(query) {
  return request({
    url: 'stat/output/CountYearRegionSales',
    method: 'get',
    params: query,
  })
}