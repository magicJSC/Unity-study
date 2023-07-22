using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Null : MonoBehaviour
{
    [SerializeField]        //여기서 지정해주않아도 오류가 뜬다
    Monster monster;
    private void Start()
    {
        //Monster를 스크립트를 사용하기위한 getcomponent
        //이걸하면 유니티에서 Monster스크립트를 이 스크립트가 있는 오브젝트에 넣어야한다 그렇지않으면 오류
        //이유 : 오브젝트를 찾을 수 없기 때문인데
        monster = GetComponent<Monster>();     
    }
}
