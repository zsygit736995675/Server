using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyServer
{
    class Program
    {
        public static void Main(string[] args)
        {
            HttpServer httpServer = new MyHttpServer(2341);
            Thread thread1 = new Thread(new ThreadStart(httpServer.listen));
            thread1.Start();
        }
    }
}