using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ArthsAppProject
{

        public class NameRule<T> : IValidationRule<T>
        {
            public string ValidationMessage { get; set; }

            public bool Check(T value)
            {
                if (value == null)
                {
                    return false;
                }

                var text = value as string;
                Regex regex = new Regex(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$");
                Match match = regex.Match(text);

                return match.Success;
            }
        }
 
}
