﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.LoggerAdapter
{
    public interface ILoggerAdapter<T>
    {
        void LogInformation(string message);
    }
}
