using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBeHaviour
{
    static Manager s_instance;
    public static Manager Instance { get { Init(); return s_instance; } } //유일한 매니저를 가져온다
    //=================================================배운부분
    InputManager _input = new InputManager();
    public static InputManager input { get { return Instance._input; } }
    void Start()
    {
        Init();
    }
    private void Update()
    {
        _input.OnUpdate();
    }
    //====================================================
    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Manager");
            if (go == null)
            {
                go = new GameObject { name = "@Manager" };
                go.AddComponent<Manager>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Manager>();
        }

    }
}
