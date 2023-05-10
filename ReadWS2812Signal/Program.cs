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
            CodeStart("ReadWS2812", 0, 0, 1, UNUSE, UNUSE, UNUSE, UNUSE, false, false, true, 24, true, false, 0, 0, false, 1);
            WrapTarget();

            Wait(true, Operands4.GPIO, 0, false, UNUSE, 9);
            In(Operands1.PINS, 1);
            Wait(false, Operands4.GPIO, 0, false, UNUSE, 0);

            Wrap();

            CodeEnd(true, "ReadWS2812.pio");

            RunEmulation(1200, "in.csv", "out.csv");

            //そのままだとウィンドウが閉じてしまうので、入力待ちにしてウィンドウを閉じないようにする。
            Console.Read();

        }
    }
}
