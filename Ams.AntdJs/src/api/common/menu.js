export function getRouteMenusApi() {
  return useGet('/menu', params, {
    // 设置为false的时候不会携带token
    token: false,
    // 开发模式下使用自定义的接口
    customDev: true,
    // 是否开启全局请求loading
    loading: true,
  })
}
