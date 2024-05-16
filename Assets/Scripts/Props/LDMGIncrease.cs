using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LDMGIncrease : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}
