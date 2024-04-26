import request from '@/utils/request'

// 查询列表
export function listArticle(query) {
  return request({
    url: 'routine/article/list',
    method: 'get',
    params: query
  })
}
// 查询最新列表
export function listNewArticle(query) {
  return request({
    url: 'routine/article/newList',
    method: 'get',
    params: query
  })
}

// 查询详细
export function getArticle(Id) {
  return request({
    url: 'routine/article/' + Id,
    method: 'get',
  })
}

// 新增
export function addArticle(data) {
  return request({
    url: 'routine/article/add',
    method: 'post',
    data: data,
  })
}

// 修改
export function updateArticle(data) {
  return request({
    url: 'routine/article/edit',
    method: 'put',
    data: data
  })
}

// 删除菜单
export function delArticle(id) {
  return request({
    url: 'routine/article/' + id,
    method: 'delete'
  })
}
// 查询菜单目录
export function listArticleCategory() {
  return request({
    url: 'routine/article/CategoryList',
    method: 'get'
  })
}
// 查询菜单目录树
export function listArticleCategoryTree() {
  return request({
    url: 'routine/article/CategoryTreeList',
    menubar: 'get'
  })
}
// 置顶
export function topArticle(data) {
  return request({
    url: '/Article/top',
    method: 'put',
    data: data
  })
}
// 是否公开
export function changeArticlePublic(data) {
  return request({
    url: '/Article/ChangePublic',
    method: 'put',
    data: data
  })
}
//排序
export function changeSort(data) {
  return request({
    url: 'article/ArticleCategory/ChangeSort',
    method: 'get',
    params: data
  })
}
