using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoSceneUI : SceneUI
{
    protected override void Awake()
    {
        base.Awake();

        texts["HeartText"].text = "20";
        texts["CoinText"].text = "100";
    }
}
