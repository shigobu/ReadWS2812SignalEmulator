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
            const string readPin = "readPin";
            const string resetCount = "resetCount";

            //元の、defineスイッチの設定を行う。
            Init(false, false, true, true);
            CodeStart("ReadWS2812", 0, 0, 1, UNUSE, UNUSE, UNUSE, UNUSE, false, false, true, 24, true, false, 0, 0, false, 1);

            Pull(false, true, UNUSE, 0);
            WrapTarget();

            Wait(true, Operands4.GPIO, 0, false);
            Label(readPin);
            Mov(Operands1.X, Operands2.NONE, Operands1.OSR);
            Nop(UNUSE, 7);
            In(Operands1.PINS, 1);
            Wait(false, Operands4.GPIO, 0, false);

            Label(resetCount);
            Jmp(Operands3.PIN, readPin);
            Jmp(Operands3.X_NEQ_0_DEC, resetCount);

            Irq(false, false, 0, false);

            Wrap();

            CodeEnd(true, "ReadWS2812.pio");

            RunEmulation(7000, "in.csv", "out.csv");

            //そのままだとウィンドウが閉じてしまうので、入力待ちにしてウィンドウを閉じないようにする。
            Console.Read();

        }
    }
}
