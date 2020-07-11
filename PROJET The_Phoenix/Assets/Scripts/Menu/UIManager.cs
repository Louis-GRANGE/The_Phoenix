using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager> {

    [SerializeField] MainMenu _mainMenu;
    [SerializeField] Camera _dummyCamera;
    public static bool start = false;
    public static bool finish = false;

    private void Update()
    {
        if (start)
        {
            _mainMenu.FadeOut();
            
        }
        if (finish)
            _mainMenu.FadeIn();
    }
    public void SetDummyCameraActive(bool active)
    {
        _dummyCamera.gameObject.SetActive(active);
    }

    public void Begin()
    {
        start = !start;
    }
}
