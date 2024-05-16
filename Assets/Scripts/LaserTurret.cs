using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LaserTurret : PrimitiveTurret
{
    private List<GameObject> enemys = new List<GameObject>();
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            enemys.Add(col.gameObject);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
            enemys.Remove(col.gameObject);
        }
    }

    public float attackRateTime = 1;
    private float timer = 0;

    public Transform firePosition;
    public Transform head;

    public float damageRate = 70;

    public LineRenderer laserRenderer;

    public GameObject laserEffect;

    [Header("Player Mode|If climb on the tower")]
    public bool playerMode = false;

    void Start()
    {
        timer = attackRateTime;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (playerMode)
        //    {
        //        playerMode = false;
        //    }
        //    else
        //    {
        //        playerMode = true;
        //    }
        //}
        if(!playerMode)
        {
            LookEnemy();
            Attack();
            GetComponentInChildren<Lasers>().enabled = false;
        }
        else
        {
            GetComponentInChildren<Lasers>().enabled = true;
        }
    }

    protected override void LookEnemy()
    {
        if (enemys.Count > 0 && enemys[0] != null)
        {
            Vector3 targetPosition = enemys[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);
        }
    }
    protected override void Attack()
    {
        if (enemys.Count > 0)  //Laser Turret
        {
            if (laserRenderer.enabled == false)
                laserRenderer.enabled = true;
            //Debug.Log(laserRenderer.enabled);
            laserEffect.SetActive(true);
            if (enemys[0] == null)
            {
                UpdateEnemys();
            }
            if (enemys.Count > 0)
            {
                laserRenderer.SetPositions(new Vector3[] { firePosition.position, enemys[0].transform.position });
                enemys[0].GetComponent<Enemy>().TakeDamage(damageRate * Time.deltaTime);
                laserEffect.transform.position = enemys[0].transform.position;
                Vector3 pos = transform.position;
                pos.y = enemys[0].transform.position.y;
                laserEffect.transform.LookAt(pos);
            }
        }
        else //if no enemy in laser turret range
        {
            laserEffect.SetActive(false);
            laserRenderer.enabled = false;
        }
    }

    void UpdateEnemys()
    {
        //enemys.RemoveAll(null);
        List<int> emptyIndex = new List<int>();
        for (int index = 0; index < enemys.Count; index++)
        {
            if (enemys[index] == null)
            {
                emptyIndex.Add(index);
            }
        }

        for (int i = 0; i < emptyIndex.Count; i++)
        {
            enemys.RemoveAt(emptyIndex[i] - i);
        }
    }

}
