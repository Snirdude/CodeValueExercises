using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    class Reader
    {
        internal List<string> ReadStringsFromFile()
        {
            FileStream fs = new FileStream("Names.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            List<string> answer;
            try
            {
                answer = new List<string>();

                while (!reader.EndOfStream)
                {
                    answer.Add(reader.ReadLine());
                }
            }
            finally
            {
                reader.Close();
                fs.Close();
            }

            return answer;
        }
    }
}
