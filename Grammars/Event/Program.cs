using System;

namespace CSarp
{
	class Program
	{
		static void OnInputTest
		{

		}
		static void Main(string[] args)
		{
			Inputmanager inputmanager = new Inputmanager();

			inputmanager.InputKey += OnInputTest;  //event인 InputKey에 OuInputTest함수를 구독한다
			while (true)
			{
				inputmanager.Update();	//Inputmanager의 Update함수를 계속실행
			}
			inputmanager.Inputkey();   //구독하지 않으면 멋대로 사용할수없다
		}
	}
}
