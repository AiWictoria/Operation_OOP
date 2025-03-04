using OperationOOP.Core.Models.Plants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Data
{
    public interface IDatabase
    {
        List<Bonsai> Bonsais { get; set; }
        List<Opuntia> Opuntias { get; set; }
        List<Polypody> Polypody { get; set; }
    }

}
