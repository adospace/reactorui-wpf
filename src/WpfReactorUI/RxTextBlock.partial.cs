using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfReactorUI
{
    public partial class RxTextBlock<T>
    {
        public RxTextBlock(string text)
        {
            this.Text(text);
        }
    }
}
