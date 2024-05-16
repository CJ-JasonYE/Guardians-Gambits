using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPIncrease : MonoBehaviour
{
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}
