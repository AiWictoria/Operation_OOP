using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Interface for watering plants and get last watered date
namespace OperationOOP.Core.Models.Interfaces
{
    interface IWater
    {
        DateTime LastWatered { get; }
        void Water();
    }
}
