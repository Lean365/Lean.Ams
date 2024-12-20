import request from '@/utils/request'

/**
 * 获取数据库
 */
export function listDataBases() {
  return request({
    url: 'tool/gen/getDbList',
    method: 'get'
  })
}
/**
 * 获取数据库表
 */
export function listDataTables(data) {
  return request({
    url: 'tool/gen/getTableList',
    method: 'get',
    params: data
  })
}

/**
 * 获取表格列信息
 * @param {*} data
 * @returns
 */
export function queryColumnInfo(tableId) {
  return request({
    url: 'tool/gen/Column/' + tableId,
    method: 'GET'
  })
}
/**
 * 查询数据库表是否存在
 * @param {*} data
 * @returns
 */
export function queryTableExists(tableName) {
  return request({
    url: 'tool/gen/getTableExists/',
    method: 'GET',
    params: { tableName } // 添加  TableName 参数
  })
}

/**
 * 创建表
 * @param {*} data
 * @returns
 */
export function addDataTable(createTableSql, tableName) {
  return request({
    url: 'tool/gen/createTable/',
    method: 'GET',
    params: { createTableSql, tableName } // 添加 tableName 和 createTableSql 参数
  })
}
/**
 * 获取表格列信息
 * @param {*} data
 * @returns
 */
export function listDataColumns(dbName, tableName) {
  return request({
    url: 'tool/gen/Column/',
    method: 'GET',
    params: { dbName, tableName } // 添加 DbName 和 TableName 参数
  })
}

// 查询生成表数据
export function listTable(params) {
  return request({
    url: 'tool/gen/list',
    method: 'get',
    params: params
  })
}

// 查询表详细信息
export function getGenTable(tableId) {
  return request({
    url: '/tool/gen/' + tableId,
    method: 'get'
  })
}

// 导入表
export function importTable(data) {
  return request({
    url: '/tool/gen/importTable',
    method: 'post',
    data: data
  })
}
// 删除表数据
export function delTable(tableId) {
  return request({
    url: '/tool/gen/' + tableId,
    method: 'delete'
  })
}

// 修改代码生成表信息
export function updateGenTable(data) {
  return request({
    url: '/tool/gen/',
    method: 'put',
    data: data
  })
}

// 预览生成代码
export function previewTable(tableId, data) {
  return request({
    url: '/tool/gen/preview/' + tableId,
    method: 'post',
    params: data
  })
}

// 同步数据库
export function synchDb(tableId, data) {
  return request({
    url: '/tool/gen/synchDb/' + tableId,
    method: 'get',
    params: data
  })
}
