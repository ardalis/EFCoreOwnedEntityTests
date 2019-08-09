using System.Collections.Generic;

namespace EFOwnedEntities
{
    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsScary { get; set; }
        public string Color { get; set; }

        public Tail Tail { get; set; }
        public List<Limb> Limbs { get; set; }
        public List<Owner> Owners { get; set; }
    }

    public class Limb
    {
        public int Id { get; set; }
        public string Covering { get; set; }
        public int Length { get; set; }
    }

    public class Tail
    {
        public string Description { get; set; }
    }

    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
