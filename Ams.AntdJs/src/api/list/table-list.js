export async function getListApi(params) {
  return usePost('/list/consult-list', params, {
    // 设置为false的时候不会携带token
    token: false,
    // 开发模式下使用自定义的接口
    customDev: true,
    // 是否开启全局请求loading
    loading: true,
  })
}
export async function deleteApi(id) {
  return useDelete(`/list/${id}`, params, {
    // 设置为false的时候不会携带token
    token: false,
    // 开发模式下使用自定义的接口
    customDev: true,
    // 是否开启全局请求loading
    loading: true,
  })
}
