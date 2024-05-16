using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PrimitiveTurret : MonoBehaviour
{
    protected abstract void Attack();
    protected abstract void LookEnemy();
}
