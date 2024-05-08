import request from '@/utils/request'

/**
 * 多语言配置分页查询
 * @param {查询条件} data
 */
export function listLocaleLang(query) {
  return request({
    url: 'system/locale/list',
    method: 'get',
    params: query
  })
}
/**
 * 多语言配置查询
 * @param {查询条件} data
 */
export function listLangByLocale(locale) {
  return request({
    url: 'system/locale/list/' + locale,
    method: 'get'
  })
}

/**
 * 新增多语言配置
 * @param data
 */
export function addLocaleLang(data) {
  return request({
    url: 'system/locale',
    method: 'post',
    data: data
  })
}

/**
 * 修改多语言配置
 * @param data
 */
export function updateLocaleLang(data) {
  return request({
    url: 'system/locale',
    method: 'PUT',
    data: data
  })
}

/**
 * 获取多语言配置详情
 * @param {Id}
 */
export function getLocaleLang(id) {
  return request({
    url: 'system/locale/' + id,
    method: 'get'
  })
}
/**
 * 获取多语言配置详情
 * @param {key}
 */
export function getLocaleLangByKey(key) {
  return request({
    url: 'system/locale/key/' + key,
    method: 'get'
  })
}

/**
 * 删除多语言配置
 * @param {主键} pid
 */
export function delLocaleLang(pid) {
  return request({
    url: 'system/locale/' + pid,
    method: 'delete'
  })
}

/**
 * 删除多语言配置
 * @param {key} langkey
 */
export function delLocaleLangByKey(langkey) {
  return request({
    url: 'system/locale/ByKey',
    method: 'delete',
    params: { langkey }
  })
}

// 导出多语言配置
export function exportLocaleLang(query) {
  return request({
    url: 'system/locale/export',
    method: 'get',
    params: query
  })
}
