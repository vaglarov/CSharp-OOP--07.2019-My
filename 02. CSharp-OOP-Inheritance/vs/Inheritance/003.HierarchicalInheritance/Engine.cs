using System;
using System.Collections.Generic;
using System.Text;

namespace Farm
{
    public class Engine
    {
        public void Run()
        {
          
            Puppy puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();
            Console.WriteLine();
            Dog dog = new Dog();
            dog.Eat();
            dog.Bark();

            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();

        }
    }
}
