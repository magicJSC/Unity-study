using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Player player01;
    private Player player02;

    private void Awake()
    {
        player01 = new Player("고박사",1000);          //얕은 복사 
        player02 = player01;                           //player01이 가리키는 곳을 player02가 가리키게됨
        player02.ID = "유니티";                        //결국 player02가 가리키는곳의 ID가 바뀌어서 player01의 ID도 바뀌것처럼됨


        player01 = new Player("고박사", 1000);          //깊은 복사
        player02 = player01.DeepCopy();                 //결국 새로 만든 곳을 가리킴
        player02.ID = "유니티";                         //새로만든곳의 ID가 달라짐
    }
}
