using System;

namespace CSharp
{
    class Program
    {
        //class MyList
        //{
        //    int[] arr = new int[10];      이렇게 형식마다 다르게 하는건 무식한 방법이다
        //}
        //class FlaotList
        //{
        //    float[] arr = new float[10];
        //}

        class MyList<T> where T : struct    //일반화 : T를 변수(int,string,float),클래스를 T에 넣어줘도 작동을 한다   where T : struct : T값이 값일때  class : 참조형식일떄  new() : 기본 생성자일떄   Monster : class
        {
            T[] arr = new T[10];

            public T GetItem(int i)    //T를 사용하는 방법
            {
                return arr[i];  
            }
        }
        class Monster
        {

        }

        static void Test<T>(T input)   //함수 일반화
        {

        }
        static void Main(string[] args)
        {
            var obj3 = 3;   //object랑 비슷한 var는 대입한 값의 따라 형식을 맞추는데
            object obj = 3;   //object는 자신 고유의 형식이다
            object obj2 = "string";
            int num = (int)obj;    //대입해줄땐 형식을 변환해준다
            string str = (string)obj2;  //하지만 넣어줄땐 속도가 느리다

            MyList<int> list= new MyList<int>();
            int item = list.GetItem(0);   //T를 사용하는 방법

            MyList<string> list2= new MyList<string>();
            MyList<Monster> list3= new MyList<Monster>();
        }
    }
}
