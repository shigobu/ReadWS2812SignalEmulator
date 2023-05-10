using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWS2812Signal
{
    class Program : PicopioEmu.Emulator
    {
        static void Main(string[] args)
        {
            //元の、defineスイッチの設定を行う。
            Init(false, false, true, true);

            CodeStartSimple("pio0_sm0", 0, 1, 1, UNUSE, UNUSE, UNUSE, UNUSE, false);
            WrapTarget();

            Nop();
            Nop();

            Wrap();

            CodeEnd(true, "pio0_sm0.pio");

            RunEmulation(1200, "in.csv", "out.csv");

            //そのままだとウィンドウが閉じてしまうので、入力待ちにしてウィンドウを閉じないようにする。
            Console.Read();

        }
    }
}
