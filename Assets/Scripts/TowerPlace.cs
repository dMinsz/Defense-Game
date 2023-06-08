using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlace : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    [SerializeField] private Color normal;
    [SerializeField] private Color mouseOver;

    private Renderer render;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }

    private void Start()
    {
        render.material.color = normal;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        BuildUI buildUI = GameManager.UI.ShowInGameUI<BuildUI>("UI/BuildMenuUI");
        buildUI.SetTowerPlace(this);
        buildUI.SetTarget(transform);
        buildUI.SetOffset(new Vector3(200, 0));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        render.material.color = mouseOver;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        render.material.color = normal;
    }

    public void BuildTower(string tower)
    {
        Debug.Log(tower);
    }


}
