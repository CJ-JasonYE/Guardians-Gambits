using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinArrow : MonoBehaviour
{
    private float rotateSpeed = 60;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
