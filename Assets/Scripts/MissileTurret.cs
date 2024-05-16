using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissileTurret : PrimitiveTurret
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

    public GameObject bulletPrefab;
    public Transform firePosition;
    public Transform firePosition2;
    public Transform head;

    public float damageRate = 70;
    public bool isUpgraded = false;

    [Header("Player Mode|If climb on the tower")]
    public bool playerMode = false;

    void Start()
    {
        timer = attackRateTime;
        cooldownTimer = coolDownTime;
    }

    void Update()
    {
        if (!playerMode)
        {
            LookEnemy();
            Attack();
        }
        else
        {
            PowerfulAim();
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
    void AttackMode()
    {
        if (enemys[0] == null)
        {
            UpdateEnemys();
        }
        if (enemys.Count > 0)
        {
            if (!isUpgraded)
            {
                GameObject bullet = GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
                bullet.GetComponent<Bullet>().SetTarget(enemys[0].transform);
            }
            else
            {
                GameObject bullet = GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
                GameObject bullet2 = GameObject.Instantiate(bulletPrefab, firePosition2.position, firePosition.rotation);
                bullet.GetComponent<Bullet>().SetTarget(enemys[0].transform);
                bullet2.GetComponent<Bullet>().SetTarget(enemys[0].transform);
            }
        }
        else
        {
            timer = attackRateTime;
        }
    }

    protected override void Attack()
    {
        timer += Time.deltaTime;
        if (enemys.Count > 0 && timer >= attackRateTime)
        {
            timer = 0;
            AttackMode();
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
            enemys.RemoveAt(emptyIndex[i]-i);
        }
    }

    [Header("PowerfulItemRef")]
    public GameObject piercingBullet;
    public float coolDownTime = 1.5f;
    private float cooldownTimer;
    private bool isButtonDown = false;
    private void PowerfulAim()
    {
        cooldownTimer += Time.deltaTime;
        if(true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Vector3 lookPos = new Vector3(hit.point.x, head.position.y, hit.point.z);
                head.LookAt(lookPos);
            }
        }
        if (cooldownTimer>=coolDownTime && Input.GetMouseButtonDown(0))
        {
            cooldownTimer = 0;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Vector3 launchPos = new Vector3(hit.point.x, firePosition.position.y, hit.point.z);
                Vector3 direction = launchPos - firePosition.position;
                
                GameObject pB = Instantiate(piercingBullet, firePosition.position, Quaternion.identity);
                pB.transform.rotation = Quaternion.LookRotation(direction);
                pB.GetComponentInChildren<PiercingBullet>().launchDir = direction;
            }
        }
    }
}
