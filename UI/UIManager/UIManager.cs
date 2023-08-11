using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int _order = 0;

    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    UI_Scene _sceneUI = null;

    public GameObject Root
    {   get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject { name = "@UI_Root" };
            return root;
        }
    } 
    public void SetCanvas(GameObject go,bool sort = true) 
    {
      Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        if (sort)
        { 
            canvas.sortingOrder = (_order);
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }
    public T ShowSceneUI<T>(string name = null) where T : UI_Scene  //UI를 나타나게 하는 함수
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");
        T sceneUI = Util.GetOrAddComponent<T>(go);
        _sceneUI = sceneUI;


        go.transform.SetParent(Root.transform);     //캔버스를 @UI_Root의 자식으로 두게한다
        return sceneUI;
    }

    public T ShowPopupUI<T>(string name = null) where T : UI_Popup 
    {
        if(string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);
        go.transform.SetParent(Root.transform);     //캔버스를 @UI_Root의 자식으로 두게한다
        
        return popup;
    }
    public void ClosePopupUI(UI_Popup popup)
    {
        if (_popupStack.Count == 0)
            return;

        if(_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup Failed!");
        }
        ClosePopupUI();
    }

    public void ClosePopupUI()  //마지막으로 나온 UI캔버스가 삭제된다
    {
        if (_popupStack.Count == 0)
            return;

        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;
        _order--;
    }
    public void CloseAllPopupUI()   //UI를 모두 지우는 함수
    {
        while(_popupStack.Count > 0)
        ClosePopupUI();

        
    }
}
