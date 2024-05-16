using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRateIncrease : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Renderer>().material.color = Color.cyan;
    }
}
