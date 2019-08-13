using System;
using System.Collections.Generic;
using System.Text;

namespace HangfireExampleCore.Core.Demo
{
    public interface IDemoService
    {
        void RunDemoTask();
    }

    public class DemoService : IDemoService
    {
        public void RunDemoTask()
        {
            Console.WriteLine("This is a task that has been ran from the demo service.");
        }
    }
}
