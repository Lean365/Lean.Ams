import request from '@/utils/request'
//获取前月库存（数量/金额）
export function getCurrentInventoryAmount(query) {
  return request({
    url: 'stat/fico/QueryInventoryAmount',
    method: 'get',
    params: query,
  })
}