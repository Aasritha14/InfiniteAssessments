using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Pattern_Assignment
{

}

interface IPrototype<T>
{
    T Clone();
}


class GameCharacter : IPrototype<GameCharacter>
{
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public List<string> Skills { get; set; } = new List<string>();

    public GameCharacter(int health, int attack, int defense, List<string> skills)
    {
        Health = health; Attack = attack; Defense = defense; Skills = skills;
    }

    // Deep clone: copies the list so clones don't share the same reference
    public GameCharacter Clone() =>
        new GameCharacter(Health, Attack, Defense, new List<string>(Skills));

    public override string ToString() =>
        $"HP:{Health}, ATK:{Attack}, DEF:{Defense}, Skills:[{string.Join(", ", Skills)}]";
}

class Program
{
    static void Main(string[] args)
    {
        // Base Prototype: Warrior
        var warriorPrototype = new GameCharacter(150, 30, 20, new List<string> { "Slash", "Block" });

        // Create units by cloning the prototype
        var warrior1 = warriorPrototype.Clone();
        warrior1.Skills.Add("Power Strike");

        var warrior2 = warriorPrototype.Clone();
        warrior2.Health = 180;

        Console.WriteLine("Prototype: " + warriorPrototype);
        Console.WriteLine("Warrior 1: " + warrior1);
        Console.WriteLine("Warrior 2: " + warrior2);
    }
}

