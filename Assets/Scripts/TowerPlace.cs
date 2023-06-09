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
        buildUI.SetOffset(new Vector3(50, 50));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        render.material.color = mouseOver;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        render.material.color = normal;
    }

    public void BuildTower(TowerData data)
    {
        GameManager.Resource.Destroy(gameObject);
        GameManager.Resource.Instantiate(data.Towers[0].tower, transform.position, transform.rotation);
    }

    public void BuildTower(TowerData.TowerInfo info)
    {
        
        GameManager.Resource.Destroy(gameObject);

        Tower tower = GameManager.Resource.Instantiate(info.tower, transform.position, transform.rotation);

        tower.GetComponentInChildren<SphereCollider>().radius = info.attackRange;
        tower.attackDamage = info.attackDamage;
        tower.attackDelay= info.attackDelay;
    }


}
