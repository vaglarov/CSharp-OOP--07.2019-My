using System;
using System.Collections.Generic;
using System.Text;

namespace Farm
{
    public class Engine
    {
        public void Run()
        {
            Dog dog = new Dog();
            dog.Eat();
            dog.Bark();
            Puppy puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();
        }
    }
}
