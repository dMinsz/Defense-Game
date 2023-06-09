using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Data/Tower")]
public class TowerData : ScriptableObject
{
    [SerializeField] public TowerInfo[] towers;
    public TowerInfo[] Towers { get { return towers; } }

    [Serializable]
    public class TowerInfo
    {
        public string name;
        public string description;

        public Tower tower;
        [Header("build Status")]
        public float buildTime;
        public float buildCost;
        public float sellCost;

        [Header("Attack Status")]
        public float attackRange;
        public int attackDamage;
        public float attackDelay;

    }
}
