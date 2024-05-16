using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawner : MonoBehaviour
{
    public GameObject LDMGIncreaseProp;
    public GameObject LRateIncreaseProp;
    public GameObject CDMGIncreaseProp;
    public GameObject CRateIncreaseProp;
    public GameObject MDMGIncreaseProp;
    public GameObject MRateIncreaseProp;
    public GameObject EnemyHPIncreaseProp;
    public GameObject EnemySpeedIncreaseProp;

    public void SpawnProp(Transform transform, int ID)
    {
        switch (ID)
        {
            case 1:
                Instantiate(LDMGIncreaseProp, transform.position, transform.rotation);
                break;
            case 2:
                Instantiate(LRateIncreaseProp, transform.position, transform.rotation);
                break;
            case 3:
                Instantiate(CDMGIncreaseProp, transform.position, transform.rotation);
                break;
            case 4:
                Instantiate(CRateIncreaseProp, transform.position, transform.rotation);
                break;
            case 5:
                Instantiate(MDMGIncreaseProp, transform.position, transform.rotation);
                break;
            case 6:
                Instantiate(MRateIncreaseProp, transform.position, transform.rotation);
                break;
            case 7:
            case 8:
                Instantiate(EnemyHPIncreaseProp, transform.position, transform.rotation);
                break;
            case 9:
            case 10:
                Instantiate(EnemySpeedIncreaseProp, transform.position, transform.rotation);
                break;
            default:
                break;
        }
    }
}
