using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.MockModuls
{
    public interface IMockData<T> where T:class
    {
        IEnumerable<T> GetMock();
    }
}
