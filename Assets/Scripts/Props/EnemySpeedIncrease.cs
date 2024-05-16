using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpeedIncrease : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }
}
