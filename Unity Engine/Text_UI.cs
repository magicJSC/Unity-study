using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;    //Type을 사용하기 위해 만든다
public class Text_UI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _text;
    int _score =0;

    Dictionary<Type, UnityEngine.Object[]>_objects=new Dictionary<Type, UnityEngine.Object[]>();
    enum Texts
    {
        PointText,
        ScoreText
    }
    enum Buttons
    {
        PointButton
    }

    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
    }
    void Bind<T>(Type type)
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T),objects);
        for(int i=0;i<names.Length;i++)
        {
            objects[i] = null;
        }
    }
    public void OnButtonClicked()
    {
        _score++;
        _text.text = $"점수 : {_score}";
    }
   
}

  