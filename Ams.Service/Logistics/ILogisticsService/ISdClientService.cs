using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 客户
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/26 15:01:09
    /// </summary>
    public interface ISdClientService : IBaseService<SdClient>
    {
        /// <summary>
        /// 获取客户列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SdClientDto> GetList(SdClientQueryDto parm);

        /// <summary>
        /// 获取客户信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        SdClient GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 客户
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        SdClient AddSdClient(SdClient parm);

        /// <summary>
        /// 更新
        /// 客户
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateSdClient(SdClient parm);


        /// <summary>
        /// 批量导入
        /// 客户
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportSdClient(List<SdClient> list);

        /// <summary>
        /// 导出
        /// 客户
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SdClientDto> ExportList(SdClientQueryDto parm);
    }
}
