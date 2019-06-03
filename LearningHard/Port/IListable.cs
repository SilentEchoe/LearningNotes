using System;
using System.Collections.Generic;
using System.Text;

namespace Port
{
    interface IListable
    {
        string[] ColumnValues { get; }
    }
}
