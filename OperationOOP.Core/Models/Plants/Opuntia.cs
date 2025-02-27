using OperationOOP.Core.Models.Interfaces;

namespace OperationOOP.Core.Models.Plants;

// Plant class for Optunia that inherits from Plant and implements IPrune but not IWater
public class Opuntia : Plant, IPrune
{
    public DateTime LastPruned { get; private set; }
    public Opuntia(int id, string name, string species, int age, CareLevel careLevel, DateTime? lastPruned = null) : base (id, name, species, age, careLevel)
    {
        LastPruned = lastPruned ?? DateTime.Now;
    }
    public void Prune()
    {
        LastPruned = DateTime.Now;
    }
}


 