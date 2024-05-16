using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Save every wave of enemies properties
[System.Serializable]
public class Wave  {
    public GameObject enemyPrefab;
    public int count;
    public float rate;
}
