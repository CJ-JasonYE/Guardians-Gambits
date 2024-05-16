using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerDamageData : MonoBehaviour
{
    public float LaserTurretDamage = 70f;
    public float MissileTurretDamage = 70f;
    public float CannonTurretDamage = 100f;

    public float LaserTurretDamageAddition = 10f;
    public float MissileTurretDamageAddition = 15f;
    public float CannonTurretDamageAddition = 25f;
    
    public LaserTurret laserTurretScript;
    public MissileTurret missileTurretScript;
    public CannonTurret cannonTurretScript;

    private void Start()
    {
        laserTurretScript.damageRate = LaserTurretDamage;
        missileTurretScript.damageRate = MissileTurretDamage;
        cannonTurretScript.damageRate = CannonTurretDamage;
    }
    public void IncreaseLaserTurretDamage()
    {
        LaserTurretDamage += LaserTurretDamageAddition;
        laserTurretScript.damageRate = LaserTurretDamage;
    }

    //public float GetLaserTurretDamage()
    //{ 
    //    return LaserTurretDamage;
    //}

    public void IncreaseMissileTurretDamage()
    {
        MissileTurretDamage += MissileTurretDamageAddition;
        missileTurretScript.damageRate = MissileTurretDamage;
    }

    //public float GetMissileTurretDamage()
    //{
    //    return MissileTurretDamage;
    //}

    public void IncreaseCannonTurretDamage()
    {
        CannonTurretDamage += CannonTurretDamageAddition;
        cannonTurretScript.damageRate = CannonTurretDamage;
    }

    //public float GetCannonTurretDamage()
    //{
    //    return CannonTurretDamage;
    //}
}
