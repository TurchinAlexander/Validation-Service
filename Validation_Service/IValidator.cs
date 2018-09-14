using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation_Service
{
    public interface IValidator
    {
        bool CheckObject(object obj);
    }
}
