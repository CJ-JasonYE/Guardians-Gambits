using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiltTurretData : MonoBehaviour
{
    public List<LaserTurret> LaserTurrets;
    public List<MissileTurret> MissileTurrets;
    public List<CannonTurret> CannonTurrets;
    public List<Enemy> Enemies;
    public void AddLTurret(GameObject newLTurret)
    {
        LaserTurrets.Add(newLTurret.GetComponent<LaserTurret>());
    }

    public void AddMTurret(GameObject newMTurret)
    {
        MissileTurrets.Add(newMTurret.GetComponent<MissileTurret>());
    }

    public void AddCTurret(GameObject newCTurret)
    {
        CannonTurrets.Add(newCTurret.GetComponent<CannonTurret>());
    }
    
    public void AddEnemy(GameObject newEnemy)
    {
        Enemies.Add(newEnemy.GetComponent<Enemy>());
    }

    public void LateUpdate()
    {
        for (int i = 0; i < Enemies.Count - 1; i++) 
        {
            if (Enemies[i] == null) 
            {
                Enemies.RemoveAt(i);
            }
        }
        for (int i = 0; i < LaserTurrets.Count - 1; i++) 
        {
            if (LaserTurrets[i] == null) 
            {
                LaserTurrets.RemoveAt(i);
            }
        }
        for (int i = 0; i < MissileTurrets.Count - 1; i++) 
        {
            if (MissileTurrets[i] == null) 
            {
                MissileTurrets.RemoveAt(i);
            }
        }
        for (int i = 0; i < CannonTurrets.Count - 1; i++) 
        {
            if (CannonTurrets[i] == null) 
            {
                CannonTurrets.RemoveAt(i);
            }
        }
    }
}
