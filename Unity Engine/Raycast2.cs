using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycst2 : MonoBehaviour
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

            Debug.DrawRay(Camera.main.transform.position,ray.direction,Color.red,1.0f);

            int mask = (1 << 8);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit,100.0f,mask))
            {
                Debug.Log($"{hit.collider.gameObject.name}");
            }
            
                                        
        }
    }
}
