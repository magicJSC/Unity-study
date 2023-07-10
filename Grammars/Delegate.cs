using System;

namespace CSharp
{
    class Program
    {
        delegate int Onclicked();   //이게 형식이 된다
        static void ButtonPressed(Onclicked clickedFunction/*함수를 인수로 남겨준다*/)
        {
            //함수 호출
            clickedFunction();
        }
        static int testDelegate
        {
            return 0;
        }
        static int testDelegate2
        {
            return 0;
        }
        static void Main(string[] args)
        {
            ButtonPressed(testDelegate);  //쓰는방법1

            Onclicked onclicked = new Onclicked(testDelegate);
            onclicked += testDelegate2;  //onclicked에 testDelgate2를 더해주면 testDelegate2도 쓸수있다
            onclicked();    //쓰는방법2

        }
    }
}
