using System;
using System.Collections.Generic;
using System.Text;

namespace PatternsLab
{
    public class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
    }

    public abstract class Enemy
    {
        private string _modelData;

        public string Name { get; set; }
        public int Health { get; set; }
        public Weapon Weapon { get; set; }
        public List<string> Abilities { get; set; } = new();
        public string ModelId => _modelData;

        protected Enemy()
        {
            Console.WriteLine("   ...loading 3D model (slow)...");
            Thread.Sleep(500);
            _modelData = "MODEL_" + Guid.NewGuid().ToString("N")[..6];
        }
        protected Enemy(Enemy target)
        {
            _modelData = target._modelData;
            Name = target.Name;
            Health = target.Health;

            Abilities = new List<string>(target.Abilities);

            if (target.Weapon == null)
            {
                Weapon = null!;
            }
            else
            {
                Weapon = new Weapon { Name = target.Weapon.Name, Damage = target.Weapon.Damage };
            }


        }

        public abstract Enemy Clone();
    }

    public class Orc : Enemy
    {
        public Orc()
        {
            Name = "Orc";
            Health = 100;
            Weapon = new Weapon { Name = "Axe", Damage = 25 };
            Abilities.Add("Rage");
        }
        private Orc(Orc other) : base(other)
        {

        }

        public override Enemy Clone()
        {
            return new Orc(this);
        }
    }

    public class Elf : Enemy
    {
        public Elf()
        {
            Name = "Elf";
            Health = 70;
            Weapon = new Weapon { Name = "Bow", Damage = 18 };
            Abilities.Add("Stealth");
        }
        private Elf(Elf other) : base(other)
        {

        }
        public override Enemy Clone()
        {
            return new Elf(this);
        }

    }


    public class Registration
    {
        private Dictionary<string, Enemy> _rigester = [];

        public void Register(string name, Enemy Prototype)
        {
            _rigester[name] = Prototype;
        }
        public Enemy GetClone(string name)
        {
            if (!_rigester.TryGetValue(name, out Enemy? prototype))
            {
                throw new ArgumentOutOfRangeException($"the {name} not found");
            }

            return prototype.Clone();
        }


    }
}
