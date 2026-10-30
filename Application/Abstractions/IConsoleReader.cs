using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Abstractions
{
    public interface IConsoleReader
    {
        public long[] ReadClientIds();
    }
}
