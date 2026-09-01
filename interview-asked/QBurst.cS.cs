using System;

namespace HelloWorld
{
    class BaseQuestion
    {
        static BaseQuestion()
        {
            Console.WriteLine("Base Static Constructor");
        }

        public BaseQuestion()
        {
            Console.WriteLine("Base Empty Constructor");
        }
    }

    class SpecialQuestion : BaseQuestion
    {
        static SpecialQuestion()
        {
            Console.WriteLine("Special Static Constructor");
        }

        public SpecialQuestion()
        {
            Console.WriteLine("Special Empty Constructor");
        }
    }

    class Hello
    {
        static void Main(string[] args)
        {
            BaseQuestion b1 = new SpecialQuestion();
            BaseQuestion b2 = new SpecialQuestion();
            BaseQuestion b3 = new SpecialQuestion();
        }
    }
}

/*
/// Output:
//Special Static Constructor
Base Static Constructor
Base Empty Constructor
Special Empty Constructor
Base Empty Constructor
Special Empty Constructor
Base Empty Constructor
Special Empty Constructor
*/ 