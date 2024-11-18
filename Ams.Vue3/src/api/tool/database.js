import request from '@/utils/request'


export function getColumnInfoList(parameter) {
  return request({
    url: '/dataBase/columnInfoList',
    method: 'get',
    params: parameter
  })
}

export function getTableInfoList() {
  return request({
    url: '/dataBase/tableInfoList',
    method: 'get'
  })
}

export function tableAdd(parameter) {
  return request({
    url: '/table/add',
    method: 'post',
    data: parameter
  })
}

export function tableEdit(parameter) {
  return request({
    url: '/table/edit',
    method: 'post',
    data: parameter
  })
}

export function tableDelete(parameter) {
  return request({
    url: '/table/delete',
    method: 'post',
    data: parameter
  })
}

export function columnAdd(parameter) {
  return request({
    url: '/column/add',
    method: 'post',
    data: parameter
  })
}

export function columnEdit(parameter) {
  return request({
    url: '/column/edit',
    method: 'post',
    data: parameter
  })
}

export function columnDelete(parameter) {
  return request({
    url: '/column/delete',
    method: 'post',
    data: parameter
  })
}

export function createEntity(parameter) {
  return request({
    url: '/table/createEntity',
    method: 'post',
    data: parameter
  })
}


