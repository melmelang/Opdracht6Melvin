﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AandeelBeheer;

namespace AandeelBeheer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        //static void MainGUI()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new Form1());
        //}

        static void Main()
        {
            AaandeelBeheerData.Rss rssdata = new AaandeelBeheerData.Rss();
            rssdata.Bewaar("Titel", "Ik", "Geen", "http://", DateTime.Now);
        }
    }
}
