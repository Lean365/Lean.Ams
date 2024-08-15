using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 客户信息
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 14:26:41
    /// </summary>
    public interface ISdClientService : IBaseService<SdClient>
    {
        /// <summary>
        /// 获取客户信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SdClientDto> GetList(SdClientQueryDto parm);

        /// <summary>
        /// 获取客户信息信息
        /// </summary>
        /// <param name="ScSfId"></param>
        /// <returns></returns>
        SdClient GetInfo(long ScSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 客户信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        SdClient AddSdClient(SdClient parm);

        /// <summary>
        /// 更新
        /// 客户信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateSdClient(SdClient parm);


        /// <summary>
        /// 批量导入
        /// 客户信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportSdClient(List<SdClient> list);

        /// <summary>
        /// 导出
        /// 客户信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SdClientDto> ExportList(SdClientQueryDto parm);
    }
}
