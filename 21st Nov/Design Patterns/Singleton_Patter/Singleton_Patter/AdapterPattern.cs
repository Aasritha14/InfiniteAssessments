using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Patter
{
    internal class AdapterPattern
    {

        public class LegacyPrinter
        {
            public void OldPrint(string text)
            {
                Console.WriteLine($"Legacy Printer printing (old way): {text}");
            }
        }



        public interface IPrinter
        {
            void Print(string text);
        }

        // Modern Printer (already matches interface)
        public class ModernPrinter : IPrinter
        {
            public void Print(string text)
            {
                Console.WriteLine($"Modern Printer printing: {text}");
            }
        }






        public class LegacyPrinterAdapter : IPrinter
        {
            private readonly LegacyPrinter legacyPrinter;// null

            public LegacyPrinterAdapter(LegacyPrinter legacyPrinter)
            {
                this.legacyPrinter = legacyPrinter;
            }

            public void Print(string text)
            {
                // Adapter translates Print() to OldPrint()
                legacyPrinter.OldPrint(text);
            }
        }


    }
}
