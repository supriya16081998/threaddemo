using System;
using System.Threading;


namespace threaddemo
{
    class Program
    {
        public static void FuncionCall1()
        {
            try
            {
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadInterruptedException te)
            {
                Console.WriteLine("cannnot sleep,interrupted by main");
            }
            finally
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
        
        public static void FunctionCall2()
        {
            Console.WriteLine("===========Child Begins Here==========");

            for (int i = 11; i <= 20; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("===========Child Ends Here==========");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("===========Main Begins Here==========");
            Thread th = Thread.CurrentThread;
            th.Name = "Main Thread";
            Console.WriteLine("Curren Thread {0}", th.Name);

            //object of thread
            ThreadStart ts1 = new ThreadStart(FuncionCall1);
            Thread t1 = new Thread(ts1);
            t1.Start();                //runnable mode
            t1.Interrupt();

            ThreadStart ts2 = new ThreadStart(FunctionCall2);
            Thread t2 = new Thread(ts2);
            t2.Start();

            Console.WriteLine("==========Main Loaded Completely============");
            Console.ReadLine();
              
        }
    }
}
