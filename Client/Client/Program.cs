﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.ExecuteClient();
            Console.ReadLine();
        }

        
    }
} 
    

