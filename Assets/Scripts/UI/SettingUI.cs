using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : SceneUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["InfoButton"].onClick.AddListener(() => { Debug.Log("Info Button"); });
        buttons["SettingButton"].onClick.AddListener(() => { OpenPausePopUpUI(); });
        buttons["VolumeButton"].onClick.AddListener(() => { Debug.Log("Volume Button"); });
    }

    public void OpenPausePopUpUI() 
    {
        //GameManager.UI.ShowPopUpUI("UI/SettingPopUp");

        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/SettingPopUpUI");
    }
}
