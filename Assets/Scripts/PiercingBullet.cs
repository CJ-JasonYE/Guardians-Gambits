using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingBullet : MonoBehaviour
{
    public int damage = 75;
    public float speed = 45;
    public Vector3 launchDir;

    private void Start()
    {
        SelfDestroy();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    private void SelfDestroy()
    {
        Destroy(gameObject.transform.parent.gameObject, 5);
    }

    private void Update()
    {
        transform.parent.Translate(launchDir.normalized * speed * Time.deltaTime, Space.World);
    }
}
