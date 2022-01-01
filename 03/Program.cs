using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace 김영휘16037010_과제03
{
        class Program
    {
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList(); // 참조 배열 생성 
            ADDR_CARD card;
            string yesno; 
            while (true)
            { 
                //입력 
                card = new ADDR_CARD(); // 객체 생성 
                //속성을 사용하여 데이터 입력 
                Console.Write("이름 : "); card.Name = Console.ReadLine();
                Console.Write("나이 : "); card.Age = Int32.Parse(Console.ReadLine());
                Console.Write("출신고 : "); card.School = Console.ReadLine();
                al.Add(card);
                Console.Write("계속 입력(y), 중지(n) : ");
               
                    yesno = Console.ReadLine();                
                if(yesno == "n") 
                    break; 
            }
            //속성을 사용하여 데이터 출력 
            Console.WriteLine("이름   나이   출신교");
            foreach (ADDR_CARD ob in al)
                Console.WriteLine("{0}   {1}   {2}", ob.Name, ob.Age, ob.School);
                //ob.Name 등을 사용하여 출력 
            
        }
    }
}
