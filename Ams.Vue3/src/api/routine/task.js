import request from '@/utils/request'

export function queryTasks(data) {
  return request({
    url: '/routine/taskqz/list',
    method: 'get',
    params: data
  })
}

export function getTasks(id) {
  return request({
    url: '/routine/taskqz/get?id=' + id,
    method: 'get'
  })
}

/**
 *
 * 获取所有任务
 * @returns
 */
export function getAllTasks() {
  return request({
    url: '/routine/taskqz/getAll',
    method: 'get'
  })
}

/**
 * 创建任务
 * @param {*} data
 * @returns
 */
export function createTasks(data) {
  return request({
    url: '/routine/taskqz/create',
    method: 'post',
    data
  })
}

/**
 * 更新任务
 * @param {*} data
 * @returns
 */
export function updateTasks(data) {
  return request({
    url: '/routine/taskqz/update',
    method: 'post',
    data
  })
}

/**
 * 删除任务
 * @param {*} id
 * @returns
 */
export function deleteTasks(id) {
  return request({
    url: '/routine/taskqz/delete?id=' + id,
    method: 'delete'
  })
}

/**
 * 启动任务
 * @param {*} id
 * @returns
 */
export function startTasks(id) {
  return request({
    url: '/routine/taskqz/start?id=' + id,
    method: 'get'
  })
}

/**
 * 停止任务
 * @param {*} id
 * @returns
 */
export function stopTasks(id) {
  return request({
    url: '/routine/taskqz/stop?id=' + id,
    method: 'get'
  })
}

/**
 * 运行一次
 * @param {*} id
 * @returns
 */
export function runTasks(id) {
  return request({
    url: '/routine/taskqz/run?id=' + id,
    method: 'get'
  })
}
/**
 * 导出
 * @returns
 */
export function exportTasks() {
  return request({
    url: '/routine/taskqz/export',
    method: 'get'
  })
}

export default { queryTasks, getTasks, getAllTasks, createTasks, updateTasks, deleteTasks, startTasks, stopTasks, runTasks, exportTasks }
