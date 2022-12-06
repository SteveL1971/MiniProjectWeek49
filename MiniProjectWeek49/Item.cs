﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectWeek49
{
    internal class Item
    {

        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int Price { get; set; }
        public List<Asset>? Assets { get; set; }


        public void printDetails(int i)
        {
            //DateTime dateInOneWeek = DateTime.Now.AddDays(7);
            //int res = DateTime.Compare(DueDate, dateInOneWeek);
            //if (res < 0 && this.Status == "Active")
            //{
            //    Console.ForegroundColor = ConsoleColor.Yellow;
            //}

            //res = DateTime.Compare(DueDate, DateTime.Now);
            //if (res < 0 && this.Status == "Active")
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //}

            //if (this.Status == "Completed")
            //{
            //    Console.ForegroundColor = ConsoleColor.Green;
            //}

            Console.WriteLine((i+1).ToString().PadRight(4) + GetType().Name.ToString().PadRight(14) + " " + Brand.PadRight(14) + " " + Model.PadRight(14) + " $" + Price.ToString().PadRight(14));
            Console.ResetColor();
        }
    }
}
