using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildUI : InGameUI
{
    private TowerPlace towerPlace;
    private TowerData towerData;

    private int towerIndex = 0;
    protected override void Awake()
    {
        base.Awake();


        buttons["BlockerButton"].onClick.AddListener(() => { CloseUI(); });
        buttons["ArchorButton"].onClick.AddListener(() => { SelectArchorTower(); });
        buttons["CanonButton"].onClick.AddListener(() => { SelectCanonTower(); });
        //buttons["BarrackButton"].onClick.AddListener(() => { });
        buttons["MageButton"].onClick.AddListener(() => { SelectMageTower(); });
        //buttons["BuildButton"].onClick.AddListener(() => { BuildTower(); });

        towerData = GameManager.Resource.Load<TowerData>("Data/TowerData");
    }

    private void OnEnable()
    {
        transforms["SubMenu"].gameObject.SetActive(false);
    }

    public void SetTowerPlace(TowerPlace towerPlace)
    {
        this.towerPlace = towerPlace;
    }

    public void SelectArchorTower()
    {
        //towerData = GameManager.Resource.Load<TowerData>("Data/TowerData");
        towerIndex = 0;
        transforms["SubMenu"].gameObject.SetActive(true);
        texts["TitleText"].text = towerData.Towers[0].name;
        texts["DescriptionText"].text = towerData.Towers[0].description;
        texts["BuildTimeText"].text = towerData.Towers[0].buildTime.ToString();
        texts["BuildCostText"].text = towerData.Towers[0].buildCost.ToString();
    }

    public void SelectCanonTower()
    {
        //towerData = GameManager.Resource.Load<TowerData>("Data/CanonTower");
        towerIndex = 1;
        transforms["SubMenu"].gameObject.SetActive(true);
        texts["TitleText"].text = towerData.Towers[1].name;
        texts["DescriptionText"].text = towerData.Towers[1].description;
        texts["BuildTimeText"].text = towerData.Towers[1].buildTime.ToString();
        texts["BuildCostText"].text = towerData.Towers[1].buildCost.ToString();
    }

    public void SelectMageTower()
    {
        //towerData = GameManager.Resource.Load<TowerData>("Data/CanonTower");
        towerIndex = 2;
        transforms["SubMenu"].gameObject.SetActive(true);
        texts["TitleText"].text = towerData.Towers[2].name;
        texts["DescriptionText"].text = towerData.Towers[2].description;
        texts["BuildTimeText"].text = towerData.Towers[2].buildTime.ToString();
        texts["BuildCostText"].text = towerData.Towers[2].buildCost.ToString();
    }


    public void BuildTower()
    {
        CloseUI();

        towerPlace.BuildTower(towerData.Towers[towerIndex]);


    }
}
