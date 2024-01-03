using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCoder_UI.lib
{
    public static class IntegerConverter
    {
        public static int IntConvert(string value)
        {
            int result = 0;

            try
            {
                result = int.Parse(value);
            }
            catch (FormatException)
            {
                AutoCoder_UI.Program.WriteToTextBox("Please enter a valid number.", Color.Red, new Font("Times New Roman", 12, FontStyle.Bold), HorizontalAlignment.Center);
             }

            return result;
        }
    }
}
