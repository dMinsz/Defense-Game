using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildUI : InGameUI
{
    private TowerPlace towerPlace;
    //private TowerData towerData;

    protected override void Awake()
    {
        base.Awake();


        buttons["BlockerButton"].onClick.AddListener(() => { CloseUI(); });
        //buttons["ArchorButton"].onClick.AddListener(() => { SelectArchorTower(); });
        //buttons["CanonButton"].onClick.AddListener(() => { SelectCanonTower(); });
        //buttons["BarrackButton"].onClick.AddListener(() => { });
        buttons["MageButton"].onClick.AddListener(() => { });
        //buttons["BuildButton"].onClick.AddListener(() => { BuildTower(); });
    }

    private void OnEnable()
    {
        //transforms["SubMenu"].gameObject.SetActive(false);
    }

    public void SetTowerPlace(TowerPlace towerPlace)
    {
        this.towerPlace = towerPlace;
    }

    //public void SelectArchorTower()
    //{
    //    towerData = GameManager.Resource.Load<TowerData>("Data/ArchorTower");

    //    transforms["SubMenu"].gameObject.SetActive(true);
    //    texts["TitleText"].text = towerData.Towers[0].name;
    //    texts["DescriptionText"].text = towerData.Towers[0].description;
    //    texts["BuildTimeText"].text = towerData.Towers[0].buildTime.ToString();
    //    texts["BuildCostText"].text = towerData.Towers[0].buildCost.ToString();
    //}

    //public void SelectCanonTower()
    //{
    //    towerData = GameManager.Resource.Load<TowerData>("Data/CanonTower");

    //    transforms["SubMenu"].gameObject.SetActive(true);
    //    texts["TitleText"].text = towerData.Towers[0].name;
    //    texts["DescriptionText"].text = towerData.Towers[0].description;
    //    texts["BuildTimeText"].text = towerData.Towers[0].buildTime.ToString();
    //    texts["BuildCostText"].text = towerData.Towers[0].buildCost.ToString();
    //}

    //public void BuildTower()
    //{
    //    CloseUI();

    //    towerPlace.BuildTower(towerData);
    //}
}
