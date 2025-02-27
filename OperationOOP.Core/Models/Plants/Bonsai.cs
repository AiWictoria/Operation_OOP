using OperationOOP.Core.Models.Interfaces;

namespace OperationOOP.Core.Models.Plants;

// Class for Bonsai plants that inherits from Plant and implements IWater and IPrune interfaces 
public class Bonsai : Plant, IWater , IPrune
{
    // Incapsulated properties for LastWatered, LastPruned and Style that can only be set in the class constructor
    public DateTime LastWatered { get; private set; }
    public DateTime LastPruned { get; private set; }
    public BonsaiStyle Style { get; private set; }
    public Bonsai(int id, string name, string species, int age, CareLevel careLevel, BonsaiStyle bonsaiStyle, DateTime? lastPruned = null, DateTime? lastWatered = null) : base (id, name, species, age, careLevel)
    {
        Style = bonsaiStyle;
        LastPruned = lastPruned ?? DateTime.Now;
        LastWatered = lastWatered ?? DateTime.Now;
    }
    public void Water()
    {
        LastWatered = DateTime.Now;
    }
    public void Prune()
    {
        LastPruned = DateTime.Now;
    }
}
public enum BonsaiStyle
{
    Chokkan,    // Formal Upright
    Moyogi,     // Informal Upright
    Shakan,     // Slanting
    Kengai,     // Cascade
    HanKengai   // Semi-cascade
}