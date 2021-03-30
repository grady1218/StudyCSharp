#define DEBUG

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StudyC____
{
    class Form1 : Form
    {
        public Form1()
        {
            Test();
        }

        [Conditional("DEBUG")]
        public void Test()
        {
            var count = 0;
            var date = DateTime.Now;

            List<int> timeList = new List<int>();

            Console.WriteLine( DateTime.Now );

            var t = new Timer
            {
                Interval = 13,
                Enabled  = true
            };

            t.Tick += (object sender, EventArgs e) => {
                if(count < 500)
                {
                    Parallel.For( 0, 1000, n => { 
                        timeList.Add((DateTime.Now - date).Milliseconds);
                        count++;
                        Console.WriteLine( count );
                    } );
                }
                else
                {
                    t.Stop();
                    Console.WriteLine( timeList.Count( ( v ) => v < 13 ) );
                }
                date = DateTime.Now;

            };


        }
    }
}
