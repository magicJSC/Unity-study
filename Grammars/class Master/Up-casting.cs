using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster
{
   public void Attack()
    {
        Debug.Log("적을 공격한다");
    }
    public void Heal()
    {
        Debug.Log("체력을 회복한다");
    }
}
public class Slime : Monster
{

    private Monster monster = new Monster();        //Monster의 Attack,Heal을 쓸수있다
    private Slime slime = new Slime();              //Slime은 Monster에게 상속을 받아서 Monster의 Attack을 쓸수있다
    private Monster monster2= new Slime();          //Monster의 Attack,Heal만 쓸수있다

   

    public void Avoid()
    {
        Debug.Log("도망가!!");
    }
    public void Heal()                              //Slime이 Monster의 Heal을 상속받아도 slime생성자는 slime의 Heal을 쓴다
    {
        Debug.Log("고블린 체력 회복");
    }
}
