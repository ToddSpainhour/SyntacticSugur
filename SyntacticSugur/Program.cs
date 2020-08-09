using System;
using System.Collections.Generic;

namespace SyntacticSugur
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's learn about expression-bodies function members in C#.");
            Console.WriteLine("\n");

            var predators = new List<string>();
            predators.Add("flyswatter");
            predators.Add("fly paper");


            var prey = new List<string>();
            prey.Add("fruit");
            prey.Add("food");


            var bug = new Bug("Jimbo", "Gnat", predators, prey);

            Console.WriteLine($"bug.FormalName returns '{bug.FormalName}'");

            Console.WriteLine($"{bug.FormalName} likes to prey on {bug.PreyList} while avoiding {bug.PredatorList()}.");

            Console.WriteLine(bug.Eat("fruit"));
            Console.WriteLine(bug.Eat("Plastic"));
        }
    }





    public class Bug
        {
            /*
                You can declare a typed public property, make it read-only,
                and initialize it with a default value all on the same
                line of code in C#. Readonly properties can be set in the
                class' constructors, but not by external code.
            */
            public string Name { get; set; } = "";
            public string Species { get; } = "";
            public List<string> Predators { get; } = new List<string>();
            public List<string> Prey { get; } = new List<string>();




        // Convert this readonly property to an expression member



        //before

        //public string FormalName
        //{
        //    get
        //    {
        //        return $"{this.Name} the {this.Species}";
        //    }
        //}


        //after

        public string FormalName => $"{this.Name} the {this.Species}";



        // expression bodied function has ()
        //public string FormalName() => $"{this.Name} the {this.Species}";


        // expression bodied property doesn't have ()
        //public string FormalName => $"{this.Name} the {this.Species}";

        // are read only, no setter only getter
        // so bug.FormalName will return thr name without calling it like function
        // access it like a property of the object that returns a value
        // can be updated every time it's called, not hardcoded




        // Class constructor
        public Bug(string name, string species, List<string> predators, List<string> prey)
            {
                this.Name = name;
                this.Species = species;
                this.Predators = predators;
                this.Prey = prey;
            }

        // constructor set things to whatever gets passed in


        // Convert this method to an expression member


        // before

            //public string PreyList()
            //{
            //    var commaDelimitedPrey = string.Join(",", this.Prey);
            //    return commaDelimitedPrey;
            //}

        // after

            public string PreyList => string.Join(",", this.Prey);
        







        // Convert this method to an expression member



        // before

        //public string PredatorList()
        //    {
        //        var commaDelimitedPredators = string.Join(",", this.Predators);
        //        return commaDelimitedPredators;
        //    }



        // after

        public string PredatorList() => string.Join(",", this.Predators);








        // Convert this to expression method



        // before

        //public string Eat(string food)
        //    {
        //        if (this.Prey.Contains(food))
        //        {
        //            return $"{this.Name} ate the {food}.";
        //        }
        //        else
        //        {
        //            return $"{this.Name} is still hungry.";
        //        }
        //    }


        //after


        public string Eat(string food) => this.Prey.Contains(food) 
                                        ? $"{this.Name} ate the {food}."
                                        : $"{this.Name} is still hungry.";
     
    }
}
