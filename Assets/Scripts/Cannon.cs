using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public QuadraticCurve curve;
    public float speed;

    private float time;

    public int damage = 75;
    public GameObject bomb;
    public GameObject bombEffect;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (curve != null)
        {
            time += Time.deltaTime * speed;
            transform.position = curve.evaluate(time);
            transform.forward = curve.evaluate(time + 0.001f) - transform.position;

            if (time >= 1)
            {
                GameObject bombGO = GameObject.Instantiate(bomb, transform.position, Quaternion.identity);
                GameObject effect = GameObject.Instantiate(bombEffect, new Vector3(transform.position.x, transform.position.y+3, transform.position.z), Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //other.GetComponent<Enemy>().TakeDamage(damage);
            //GameObject bombGO = GameObject.Instantiate(bomb,transform.position,Quaternion.identity);
            //Destroy(gameObject);
        }
    }
}
