using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : SceneUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["InfoButton"].onClick.AddListener(() => { OpenInfoWindowUI(); });
        buttons["SettingButton"].onClick.AddListener(() => { OpenPausePopUpUI(); });
        buttons["VolumeButton"].onClick.AddListener(() => { Debug.Log("Volume Button"); });
        buttons["GameEndButton"].onClick.AddListener(() => { Application.Quit(); });
    }

    public void OpenPausePopUpUI() 
    {
        //GameManager.UI.ShowPopUpUI("UI/SettingPopUp");

        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/SettingPopUpUI");
    }

    public void OpenInfoWindowUI() 
    {
        GameManager.UI.ShowWindowUI<WindowUI>("UI/InfoWindow");
    }
}
