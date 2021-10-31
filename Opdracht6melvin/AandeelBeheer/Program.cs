using System;
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
            rssdata.ConnectionString = @"Data Source=(LocalDB)\v11.0;  
			 AttachDbFilename=C:\Users\angeli melvin\source\repos\Opdracht6melvin\AandeelBeheer\AandelenBeheer.mdf; 
			 Integrated Security=True;   Connect Timeout=30";
            rssdata.Bewaar("Titel", "Ik", "Geen", "http://", DateTime.Now);
        }
    }
}
