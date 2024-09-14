using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 序列号扫描
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:36:33
    /// </summary>
    public interface IQmSerialService : IBaseService<QmSerial>
    {
        /// <summary>
        /// 获取序列号扫描列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmSerialDto> GetList(QmSerialQueryDto parm);

        /// <summary>
        /// 获取序列号扫描信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        QmSerial GetInfo(int Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 序列号扫描
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        QmSerial AddQmSerial(QmSerial parm);

        /// <summary>
        /// 更新
        /// 序列号扫描
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmSerial(QmSerial parm);


        /// <summary>
        /// 批量导入
        /// 序列号扫描
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmSerial(List<QmSerial> list);

        /// <summary>
        /// 导出
        /// 序列号扫描
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmSerialDto> ExportList(QmSerialQueryDto parm);
    }
}
