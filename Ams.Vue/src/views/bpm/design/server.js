import request from '@/utils/request';
const url = 'http://localhost:8088'

/**
 * 添加（编辑）工作流
 * @param {*} data
 * @returns
 */
export function addFlow(data) {
  return request({
    url: url + '/flow/addFlow',
    method: 'post',
    data,
  });
}

/**
 * 查询工作流
 * @param {*} data
 * @returns
 */
export function infoFlow(data) {
  return request({
    url: url + '/flow/infoFlow',
    method: 'post',
    data,
  });
}

/**
 * 删除工作流
 * @param {*} data
 * @returns
 */
export function deleteFlow(data) {
  return request({
    url: url + '/flow/deleteFlow',
    method: 'post',
    data,
  });
}

/**
 * 获取工作流定义
 * @param {*} data
 * @returns
 */
export function getDeployList(data) {
  return request({
    url: url + '/flow/getDeployList',
    method: 'post',
    data,
  });
}

/**
 * 工作流实例
 * @param {*} data
 * @returns
 */
export function flowRun(data) {
  return request({
    url: url + '/flow/deploymentRun',
    method: 'post',
    data,
  });
}
