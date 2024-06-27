import request from '@/utils/request'

/**
 * 文章目录分页查询
 * @param {查询条件} data
 */
export function listArticleCatalog(query) {
  return request({
    url: 'routine/article/catalog/list',
    method: 'get',
    params: query
  })
}

/**
 * 文章目录tree查询
 * @param {查询条件} data
 */
export function treelistArticleCatalog(query) {
  return request({
    url: 'routine/article/catalog/treelist',
    method: 'get',
    params: query
  })
}

/**
 * 新增文章目录
 * @param data
 */
export function addArticleCatalog(data) {
  return request({
    url: 'routine/article/catalog',
    method: 'post',
    data: data
  })
}

/**
 * 修改文章目录
 * @param data
 */
export function updateArticleCatalog(data) {
  return request({
    url: 'routine/article/catalog',
    method: 'PUT',
    data: data
  })
}

/**
 * 获取文章目录详情
 * @param {Id}
 */
export function getArticleCatalog(id) {
  return request({
    url: 'routine/article/catalog/' + id,
    method: 'get'
  })
}

/**
 * 删除文章目录
 * @param {主键} pid
 */
export function delArticleCatalog(pid) {
  return request({
    url: 'routine/article/catalog/' + pid,
    method: 'delete'
  })
}

// 导出文章目录
export function exportArticleCatalog(query) {
  return request({
    url: 'routine/article/catalog/export',
    method: 'get',
    params: query
  })
}

export function changeSort(data) {
  return request({
    url: 'routine/article/catalog/ChangeSort',
    method: 'get',
    params: data
  })
}
