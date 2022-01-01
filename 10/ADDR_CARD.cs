using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 김영휘_과제_10_01
{
    [Serializable]
    class ADDR_CARD
    {
        public string name;
        public string number;
        public string major;
        public ADDR_CARD(string n, string nb, string m)
        {
            this.name = n;
            this.number = nb;
            this.major = m;
        }
    }
}
