using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Interface for pruning plants and get last pruned date
namespace OperationOOP.Core.Models.Interfaces
{
    interface IPrune
    {
        DateTime LastPruned { get; }
        void Prune();
    }
}
