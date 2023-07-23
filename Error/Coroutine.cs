using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Talk());
    }
    
    
    
    //IEnumerator가 아닌 IEnumerable을 쓰면
    //coroutine을 string으로 바꿀 수 없다고 하며 에러
    //헷갈리지 않게 주의
    private IEnumerator Talk()           
    {
        yield return null;
    }
}
