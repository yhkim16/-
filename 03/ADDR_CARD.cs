using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 김영휘16037010_과제03
{
    public class ADDR_CARD
    {
        private string name, highschool;
        private int age; //name, age, highschool에 대한 속성 정의 
        public string Name
        {
            //전용 멤버 name의 속성 정의     
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            //전용 멤버 age의 속성 정의     
            get { return age; }
            set { age = value; }
        }
        public string School
        {
            //전용 멤버 highschool의 속성 정의     
            get { return highschool; }
            set { highschool = value; }
        }
    }
}
