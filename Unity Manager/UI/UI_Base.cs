using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _lists = new Dictionary<Type, UnityEngine.Object[]>();
    protected void Choice<T>(Type type) where T : UnityEngine.Object          //type은 enum을 받는다
    {
        string[] lists = Enum.GetNames(type);       //string배열로 반환
        UnityEngine.Object[] objects = new UnityEngine.Object[lists.Length];  //enum List의 길이만큼 오브젝트를 value에 넣어준다
        _lists.Add(typeof(T), objects);
        for (int i = 0; i < lists.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))                              //Object와 typeof(T)는 enum의 type이다
                objects[i] = Util.FindChild(gameObject, lists[i], true);      //enum에 차례대로 배열에 들어간다,Util에 FIndCild를 한다
            else
                objects[i] = Util.FindChild<T>(gameObject, lists[i], true);
        }
    }

    protected T Get<T>(int index) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_lists.TryGetValue(typeof(T), out objects) == false)              //Get에서 TryGetValue를 할때 실패하면 null을 return
            return null;

        return objects[index] as T;
    }
    protected TextMeshProUGUI GetText(int index)
    {
        return Get<TextMeshProUGUI>(index);
    }
    protected Image GetImage(int index)
    {
        return Get<Image>(index);
    }
    public static void AddUIEvent(GameObject go, Action<PointerEventData> action,Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Event evt = Util.GetOrAddComponent<UI_Event>(go);
        if (evt == null)
        {
            go.AddComponent<UI_Event>();
        }
        switch (type)
        {
            case Define.UIEvent.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
        }
    }
}
