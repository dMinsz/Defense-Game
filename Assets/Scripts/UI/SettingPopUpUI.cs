using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["ContinueButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
        buttons["QuitButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
        buttons["SettingButton"].onClick.AddListener(() => { OpenGameSettingPopUpUI();  });
    }

    public void OpenGameSettingPopUpUI()
    {
        //GameManager.UI.ShowPopUpUI("UI/SettingPopUp");

        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/GameSettingUI");
    }
}
