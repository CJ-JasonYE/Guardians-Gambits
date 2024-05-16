using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretData  {
    public GameObject turretPrefab;
    public int cost;
    public GameObject turretUpgradedPrefab;
    public int costUpgraded;
    public TurretType type;
    public bool Upgraded;
}
public enum TurretType
{
    LaserTurret,
    MissileTurret,
    CannonTurret
}