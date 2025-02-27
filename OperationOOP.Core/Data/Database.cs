using OperationOOP.Core.Models.Plants;

namespace OperationOOP.Core.Data
{
    public class Database : IDatabase
    {
        public List<Bonsai> Bonsais { get; set; } = new List<Bonsai>();
        public List<Opuntia> Opuntias { get; set; } = new List<Opuntia>();
    }
}
