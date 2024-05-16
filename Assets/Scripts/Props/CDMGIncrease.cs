using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDMGIncrease : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Renderer>().material.color = Color.gray;
    }
}
