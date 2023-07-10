using System;


namespace CSarp
{
    public delegate void OnInputKey()
    public event OnInputKey InputKey;   //event로 구독신청을한 곳만 delegate를 쓸수있다
    class InputManager
    {
        public void Update()
        {
            if(Console.KeyAvailable == false)
                return;
            ConsoleKeyInfo info = ConSole.ReadKey();
            if (info.Key == ConsoleKey,A)
            {
                InputKey();
            }

        }
    }
}