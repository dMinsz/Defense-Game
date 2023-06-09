using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    public void SetStart() 
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
