using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRateIncrease : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }
}
