using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour
{
    

    
    void Start()
    {
        
    }

    
    void Update()
    {

        //Debug.Log(Input.mousePosition);  //마우스의 좌표(2d)를 스크린의 위치마다 다르게 좌표를 출력
        
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));  //스크린에 있는 마우스의 위치에 따른 비율을 출력

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);  //아래의 주석들을 전부 이걸로 대체가능
            /*
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            Vector3 dir = mousePos - transform.position;  //방향
            dir = dir.normalized; //방향을 1.0f로만
            */


            Debug.DrawRay(Camera.main.transform.position, dir,Color.red,1.0f);
            
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit,100.0f))
            {
                Debug.Log($"{hit.collider.gameObject.name}");
            }
            
                                        //포지션                ,방향,hit    ,범위 
                if(Physics.Raycast(Camera.main.transform.position,dir,out hit,100.0f))
                {
                    Debug.Log($"{hit.collider.gameObject.name}");
                }
        }
    }
}
