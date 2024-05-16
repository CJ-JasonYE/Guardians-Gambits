using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBomb : MonoBehaviour
{
    private int damage = 35;
    private void Start()
    {
        Destroy(gameObject,0.25f);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log("damge");
        }
    }
}
