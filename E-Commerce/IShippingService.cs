using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    internal interface IShippingService
    {
        string GetName(string name);
        double GetWeight(double weight, int quantity);
    }
}
