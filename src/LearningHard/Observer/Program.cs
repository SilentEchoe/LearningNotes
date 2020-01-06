using System;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Subscriber LearningHardSub = new Subscriber("LearningHard");
                        TenxunGame txGame = new TenxunGame(); 
            txGame.Subscriber = LearningHardSub;
                         txGame.Symbol = "TenXun Game";
                         txGame.Info = "Have a new game published ....";
             txGame.Update();
            Console.ReadLine();
        }
    }
}
