using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player
{
    public string ID;
    private int currentHP;
    public Player DeepCopy()
    {
        Player clone = new Player();        //Player에 clone을 생성해
        clone.ID = ID;                      //ID와 currentHP를 바꿈
        clone.currentHP = currentHP;

        return clone;                       //바로 return
    }
}
