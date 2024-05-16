using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PropManager : MonoBehaviour
{
    public BuiltTurretData BTD;

    //public void Start()
    //{
    //    Debug.Log($"Diff: {StaticData.GameDifficultyMultiplier}");
    //    Debug.Log($"Speed multi: {StaticData.EnemySpeedMultiplier}, HP multi: {StaticData.EnemyHPMultiplier}");
    //    //Debug.Log($"Speed: {speed}, HP: {hp}");
    //}

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("LDMGIncreaseProp"))
        {
            Destroy(collision.gameObject);
            foreach(LaserTurret LT in BTD.LaserTurrets)
            {
                LT.damageRate += 4f;
            }
        }
        else if(collision.gameObject.name.Contains("LRateIncreaseProp"))
        {
            Destroy(collision.gameObject);
            foreach (LaserTurret LT in BTD.LaserTurrets)
            {
                LT.attackRateTime *= 0.97f;
            }
        }
        else if (collision.gameObject.name.Contains("CDMGIncreaseProp"))
        {
            Destroy(collision.gameObject);
            foreach (CannonTurret CT in BTD.CannonTurrets)
            {
                CT.damageRate += 6f;
            }
        }
        else if (collision.gameObject.name.Contains("CRateIncreaseProp"))
        {
            Destroy(collision.gameObject);
            foreach (CannonTurret CT in BTD.CannonTurrets)
            {
                Debug.Log("Found");
                CT.attackRateTime *= 0.97f;
            }
        }
        else if (collision.gameObject.name.Contains("MDMGIncreaseProp"))
        {
            Destroy(collision.gameObject);
            foreach (MissileTurret MT in BTD.MissileTurrets)
            {
                Debug.Log("Found");
                MT.damageRate += 9f;
            }
        }
        else if (collision.gameObject.name.Contains("MRateIncreaseProp"))
        {
            Destroy(collision.gameObject);
            foreach (MissileTurret MT in BTD.MissileTurrets)
            {
                MT.attackRateTime *= 0.97f;
            }
        }
        else if(collision.gameObject.name.Contains("EnemyHPIncreaseProp"))
        {
            Destroy(collision.gameObject);
            StaticData.EnemyHPMultiplier *= 1.0005f;
        }
        else if(collision.gameObject.name.Contains("EnemySpeedIncreaseProp"))
        {
            Destroy(collision.gameObject);
            StaticData.EnemySpeedMultiplier *= 1.002f;
        }
    }
}
