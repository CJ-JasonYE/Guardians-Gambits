using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MDMGIncrease : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }
}
