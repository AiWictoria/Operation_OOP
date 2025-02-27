using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models.Plants
{
    // Base abstract class for all plants with ID, name, species, age and care level, that can be overriden by derived classes
    public abstract class Plant
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Species { get; private set; }
        public int AgeYears { get; private set; }
        public CareLevel CareLevel { get; private set; }
        protected Plant(int id, string name, string species, int age, CareLevel careLevel)
        {
            Id = id;
            Name = name;
            Species = species;
            AgeYears = age;
            CareLevel = careLevel;
        }
    }
    public enum CareLevel
    {
        Beginner,
        Intermediate,
        Advanced,
        Master
    }
}
