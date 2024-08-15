import request from '@/utils/request'

/**
* 文件存储分页查询
* @param {查询条件} data
*/
export function listFileStorage(query) {
  return request({
    url: 'routine/file/stroage/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增文件存储
* @param data
*/
export function addFileStorage(data) {
  return request({
    url: 'routine/file/stroage',
    method: 'post',
    data: data,
  })
}

/**
* 修改文件存储
* @param data
*/
export function updateFileStorage(data) {
  return request({
    url: 'routine/file/stroage',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取文件存储详情
* @param {Id}
*/
export function getFileStorage(id) {
  return request({
    url: 'routine/file/stroage/' + id,
    method: 'get'
  })
}

/**
* 删除文件存储
* @param {主键} pid
*/
export function delFileStorage(pid) {
  return request({
    url: 'routine/file/stroage/' + pid,
    method: 'delete'
  })
}

// 导出文件存储
export function exportFileStorage(query) {
  return request({
    url: 'routine/file/stroage/export',
    method: 'get',
    params: query
  })
}

