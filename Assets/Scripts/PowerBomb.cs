using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBomb : MonoBehaviour
{
    private int damage = 150;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
