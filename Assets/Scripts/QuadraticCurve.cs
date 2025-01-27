using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadraticCurve : MonoBehaviour
{
    public Transform start;
    public Vector3 end;
    public Transform control;

    public Vector3 evaluate(float t)
    {
        Vector3 ac = Vector3.Lerp(start.position, control.position, t);
        Vector3 cb = Vector3.Lerp(control.position, end, t);
        return Vector3.Lerp(ac, cb, t);
    }

    //private void OnDrawGizmos()
    //{
    //    if (start == null || end == null || control == null) return;
    //    for(int i = 0; i < 20; i++)
    //    {
    //        Gizmos.DrawWireSphere(evaluate(i / 20f), 0.1f);
    //    }
    //}
}
