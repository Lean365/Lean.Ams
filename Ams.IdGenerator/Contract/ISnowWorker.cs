using System;
using System.Collections.Generic;
using System.Text;

namespace Ams.IdGenerator
{
    internal interface ISnowWorker
    {
        Action<OverCostActionArg> GenAction { get; set; }

        long NextId();
    }
}
