import request from '@/utils/request'

// 查询调度日志列表
export function listTasksqzLog(query) {
  return request({
    url: 'monitor/tasksqz/list',
    method: 'get',
    params: query
  })
}

// 删除调度日志
export function delTasksqzLog(TasksqzLogId) {
  return request({
    url: 'monitor/tasksqz/' + TasksqzLogId,
    method: 'delete'
  })
}

// 清空调度日志
export function cleanTasksqzLog() {
  return request({
    url: 'monitor/tasksqz/clean',
    method: 'delete'
  })
}

// 导出调度日志
export function exportTasksqzLog(query) {
  return request({
    url: 'monitor/tasksqz/export',
    method: 'get',
    params: query
  })
}