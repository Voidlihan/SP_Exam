using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SP_Exam
{
    public class IteratorWrite
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string Text { get; set; } = String.Empty;
        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        public void TextFunc(object n)
        {
            Text += n.ToString() + " ";
        }
    }
}
