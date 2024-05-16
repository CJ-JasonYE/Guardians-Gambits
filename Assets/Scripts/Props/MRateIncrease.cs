using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRateIncrease : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Renderer>().material.color = Color.magenta;
    }
}
