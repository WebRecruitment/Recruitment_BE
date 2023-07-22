using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRecruitment.Application.Common
{
    public class Space
    {
        public string FormatStringWithLineBreak(string input)
        {
            StringBuilder formattedString = new StringBuilder();

            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    count++;
                }
                else
                {
                    count = 0;
                }

                formattedString.Append(input[i]);

                if (count >= 2)
                {
                    formattedString.AppendLine();
                    count = 0;
                }
            }

            return formattedString.ToString();
        }
    }
}
