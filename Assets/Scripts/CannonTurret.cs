using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonTurret : PrimitiveTurret
{
    [Header("TurretPosition")]
    public Transform firePosition;
    [Header("EnemyPosition")]
    public Vector3 EnemyPosition;
    [Header("Control Point")]
    private Vector3 control;
    private GameObject controlGO;
    public float height = 15;

    public bool isPowerful = false;


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

    public float attackRateTime = 3;
    private float timer = 0;

    public GameObject cannonPrefab;
    public Transform head;

    public float damageRate = 100;
    public bool isUpgraded = false;

    [Header("Player Mode|If climb on the tower")]
    public bool playerMode = false;
    public float coolDownTime = 6;

    protected override void Attack()
    {
        timer += Time.deltaTime;
        if (enemys.Count > 0 && timer >= attackRateTime)
        {
            timer = 0;
            AttackMode();
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
                EnemyPosition = enemys[0].transform.position;
                Vector3 tempPosition = (EnemyPosition + firePosition.position) / 2;
                control = new Vector3(tempPosition.x, height, tempPosition.z);
                controlGO = new GameObject("Control");
                controlGO.transform.position = control;
                controlGO.transform.AddComponent<QuadraticCurve>();
                controlGO.transform.GetComponent<QuadraticCurve>().start = firePosition;
                controlGO.transform.GetComponent<QuadraticCurve>().end = EnemyPosition;
                controlGO.transform.GetComponent<QuadraticCurve>().control = controlGO.transform;

                GameObject cannonGo = GameObject.Instantiate(cannonPrefab, firePosition.position, firePosition.rotation);
                cannonGo.GetComponent<Cannon>().curve = controlGO.GetComponent<QuadraticCurve>();

                //Clear Reference
                //EnemyTrans = null;
                Destroy(controlGO,2);
                //controlGO = null;
            }
            else
            {
                CreateCurve();
                GameObject cannonGo = GameObject.Instantiate(cannonPrefab, firePosition.position, firePosition.rotation);
                cannonGo.GetComponent<Cannon>().curve = controlGO.GetComponent<QuadraticCurve>();

                //Clear Reference
                //EnemyPosition = Vector3.zero;
                Destroy(controlGO,2);
                //controlGO = null;
            }
        }
        else
        {
            timer = attackRateTime;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = attackRateTime;
        cooldownTimer = coolDownTime;
    }

    // Update is called once per frame
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

    void CreateCurve()
    {
        
    }

    public GameObject circlePrefab; 
    public float circleHeightOffset = 1f;
    bool isButtonDown = false;
    private GameObject circle = null;
    public GameObject explosionEffect;
    private Vector3 hitPosition;
    private float cooldownTimer;

    private void PowerfulAim()
    {
        cooldownTimer += Time.deltaTime;
        if (!isButtonDown && cooldownTimer >= coolDownTime)
        {
            isButtonDown = true;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float height = 0;

                Vector3 spawnPosition = new Vector3(hit.point.x, height + circleHeightOffset, hit.point.z);
                GameObject newObject = Instantiate(circlePrefab, spawnPosition, Quaternion.identity);
                newObject.transform.rotation = Quaternion.Euler(90, 0, 0);
                circle = newObject;

                Vector3 mousePosition = hit.point;
                mousePosition.y = height + circleHeightOffset;
                newObject.transform.position = mousePosition;
            }
        }
        if (isButtonDown)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float height = 0;

                Vector3 mousePosition = hit.point;
                mousePosition.y = height + circleHeightOffset;
                circle.transform.position = mousePosition;
                hitPosition = circle.transform.position;
            }
        }
        if (isButtonDown && Input.GetMouseButtonDown(0))
        {
            isButtonDown = false;
            cooldownTimer = 0;
            GameObject.Instantiate(explosionEffect, hitPosition, Quaternion.identity);
            Destroy(circle);
            circle = null;
        }
    }
}
