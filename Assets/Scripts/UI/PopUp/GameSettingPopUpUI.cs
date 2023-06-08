using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["SaveButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
        buttons["CancleButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });

    }

}
