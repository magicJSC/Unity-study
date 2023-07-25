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


    public GameObject ScanObj = null;
    [SerializeField]
    TalkManager TalkManager;
    [SerializeField]
    Rigidbody2D Rigid;
    [SerializeField]
    ProcessManager QuestManager;
    [SerializeField]
    ObjectTalkManager ObjectTalkManager;
    [SerializeField]
    Menu menu;
    [SerializeField]
    SavePoint save;
    public bool ismenu = false;
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
        LayerMask mask = LayerMask.GetMask("Npc") | LayerMask.GetMask("Object") | LayerMask.GetMask("SavePoint");
        RaycastHit2D hit =Physics2D.Raycast(transform.position,Look,1f,mask);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject != null)
            {
                ScanObj = hit.collider.gameObject;
                QuestManager.Interact(); 
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ismenu = true;
            menu.enabled = true;
            menu.gameObject.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        if(TalkManager.IsTalking == false)
        Rigid.MovePosition(transform.position + Dir * Speed * Time.deltaTime);
    }
}

