using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    
    internal class ActionAndFunc
    {
        //delegate에 반환값이 없으면 Action,있으면 Func
        delegate string MyDelegate<T1, T2>(T1 a, T2 b);   
        MyDelegate<int, int> myDelegate;

        Action<int, int> myDelegate2;

        //마지막은 반환타입을 넣어준다
        Func<int , int,string> myDelegate3;

        void Start()
        {
            myDelegate3 = (int a, int b) => { int sum = a + b; return sum + "리턴되었습니다"; };

            myDelegate3(3, 5);
        }
    }
}
