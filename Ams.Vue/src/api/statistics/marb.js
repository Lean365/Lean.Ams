import request from '@/utils/request'
/**
* 根据类型生成物料号
* @param query
*/
export function getMaterialNo(query) {
  return request({
    url: 'stat/marb/MaterialNo',
    method: 'get',
    params: query,
  })
}
