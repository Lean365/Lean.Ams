using System;
using System.Text;

namespace Ams.Infrastructure.Helper
{
    /// <summary>
    /// 随机数帮助类
    /// @author Lean365(Davis Ching)
    /// @date 2024-02-01
    /// </summary>
    public class RandomHelper
    {
        /// <summary>
        /// 生成n为验证码
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GeneratorNum(int Length)
        {
            char[] constant = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            StringBuilder newRandom = new(constant.Length);
            Random rd = new();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(constant.Length - 1)]);
            }
            return newRandom.ToString();
        }
    }
}