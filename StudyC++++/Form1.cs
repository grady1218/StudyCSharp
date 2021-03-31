#define DEBUG

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

            var t = new System.Windows.Forms.Timer
            {
                Interval = 13,
                Enabled  = true
            };

            t.Tick += (object sender, EventArgs e) => {
                if(count < 500)
                {
                    Parallel.For( 0, 500, n => { 
                        timeList.Add((DateTime.Now - date).Milliseconds);
                        count++;
                        TestAction( count, c => { Console.WriteLine( c ); } );
                    } );
                }
                else
                {
                    t.Stop();

                    var r = from v in timeList where v > 10 select v;

                    Console.WriteLine( r.Count() );
                }
                date = DateTime.Now;

            };

        }
        public void TestAction(int a, Action<int> callback)
        {
            Console.WriteLine( "処理中" );
            Thread.Sleep( 100 );
            Console.WriteLine("処理完了");
            callback( a * 2 );
        }
    }
}
