using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 生产班组
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:53:14)
    /// </summary>
    public interface ILineService : IBaseService<Line>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<LineDto> GetList(LineQueryDto parm);

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="PlSFID"></param>
        /// <returns></returns>
        Line GetInfo(long PlSFID);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString);


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        Line AddLine(Line parm);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateLine(Line parm);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportLine(List<Line> list);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<LineDto> ExportList(LineQueryDto parm);
    }
}
