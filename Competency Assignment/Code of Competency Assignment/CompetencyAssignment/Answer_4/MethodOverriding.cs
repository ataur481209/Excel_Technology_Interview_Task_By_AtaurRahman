using System;

namespace Answer_4
{
    public class BaseClass
    {
        public virtual void Greetings()
        {
            Console.WriteLine("Muslim: As-Salamu-Alaikum");
        }
    }

    public class SubClass : BaseClass
    {
        public override void Greetings()
        {
            Console.WriteLine("Hindu: Namaskar");
        }
    }

}
