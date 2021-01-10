using System;
using System.Collections.Generic;
using System.Text;

namespace MLog.Abstract
{
    public interface IMLogger
    {
        void Info(string message);
        void Info(Exception ex);
    }
}
