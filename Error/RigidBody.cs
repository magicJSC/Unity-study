using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.PlayerSettings;

public class Player : MonoBehaviour
{
    private float Speed  = 8f;    //플레이어의 이동속도
    public Vector3 Dir = Vector3.zero;     //플레이어의 방향
    Animator Ani;                           //플레이어 에니메이션을 위한 animator
    Vector3 Look = Vector3.zero;

    private void Start()
    {
        
        Ani = GetComponent<Animator>();
        
    }
    
    private void Update()
    {

        float x = (Input.GetAxisRaw("Horizontal"));
        float y = (Input.GetAxisRaw("Vertical"));
        if (TalkManager.IsTalking == false && ObjectTalkManager.IsTalking == false && ismenu == false && save.Saving == false)
        {
            Dir = new Vector3(x, y);
            if (Ani.GetInteger("Horizontal") != x)
            {
                Ani.SetInteger("Horizontal", (int)x);
                Ani.SetBool("IsChanging", true);
            }
            else if (Ani.GetInteger("Vertical") != y)
            {
                Ani.SetInteger("Vertical", (int)y);
                Ani.SetBool("IsChanging", true);
            }
            else
            {
                Ani.SetBool("IsChanging", false);
            }
            if (Dir.x != 0 || Dir.y != 0)
            { Look = Dir; }
            Debug.DrawRay(transform.position, Look, Color.yellow);
        }
       
    }
    private void FixedUpdate()
    {
        //Transform으로 위치 변경을 하고 collider하면 캐릭터가 떨리는 현상이 발생 하는데 RigidBody로 해결할수있다
        if(TalkManager.IsTalking == false)
        Rigid.MovePosition(transform.position + Dir * Speed * Time.deltaTime);        
    }
}

