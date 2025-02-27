using OperationOOP.Core.Models.Interfaces;

namespace OperationOOP.Core.Models.Plants;

// Plant class for Polypody that inherits from Plant and implements IWater but not IPrune
public class Polypody : Plant, IWater
{
    public DateTime LastWatered { get; private set; }
    public Polypody(int id, string name, string species, int age, CareLevel careLevel, DateTime? lastWatered = null) : base (id, name, species, age, careLevel)
    {
        LastWatered = lastWatered ?? DateTime.Now;
    }
    public void Water()
    {
        LastWatered = DateTime.Now;
    }
}


 