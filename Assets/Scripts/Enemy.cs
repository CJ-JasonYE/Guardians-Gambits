using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float speed = 10;
    public float hp = 150;
    private float totalHp;
    public GameObject explosionEffect;
    private Slider hpSlider;
    private Transform[] positions;
    private int index = 0;
    private Animator animator;
    public int money;
    public int score;
    public PropSpawner propSpawner;

	// Use this for initialization
	void Start () {
        positions = Waypoints.positions;
        hp *= StaticData.GameDifficultyMultiplier * StaticData.EnemyHPMultiplier;
        speed *= StaticData.EnemySpeedMultiplier;
        //Debug.Log($"Diff: {StaticData.GameDifficultyMultiplier}");
        //Debug.Log($"Speed multi: {StaticData.EnemySpeedMultiplier}, HP multi: {StaticData.EnemyHPMultiplier}");
        //Debug.Log($"Speed: {speed}, HP: {hp}");

        hpSlider = GetComponentInChildren<Slider>();
        animator = GetComponent<Animator>();
        totalHp = hp;
    }

	// Update is called once per frame
	void Update () {
        Move();
	}


    void Move()
    {
        if (Vector3.Distance(transform.position, positions[index].position) < 0.1f)
        {
            MoveToNextWaypoint();
        }

        if (index < positions.Length)
        {
            transform.LookAt(positions[index].position);

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            animator.CrossFade("Run", 0.1f);
        }
    }
    
    void ReachDestination()
    {
        GameManager.Instance.Failed();
        GameObject.Destroy(this.gameObject);
    }


    void OnDestroy()
    {
        EnemySpawner.CountEnemyAlive--;
        int PropChooser = Random.Range(1, 11);
        switch (PropChooser)
        {
            case 1:
                if(Random.Range(1,101) >= 80)
                {
                    propSpawner.SpawnProp(gameObject.transform, PropChooser); 
                }
                break;
            case 2:
                if (Random.Range(1, 101) >= 70)
                {
                    propSpawner.SpawnProp(gameObject.transform, PropChooser);
                }
                break;
            case 3:
                if (Random.Range(1, 101) >= 70)
                {
                    propSpawner.SpawnProp(gameObject.transform, PropChooser);
                }
                break;
            case 4:
                if (Random.Range(1, 101) >= 60)
                {
                    propSpawner.SpawnProp(gameObject.transform, PropChooser);
                }
                break;
            case 5:
                if (Random.Range(1, 101) >= 60)
                {
                    propSpawner.SpawnProp(gameObject.transform, PropChooser);
                }
                break;
            case 6:
                if (Random.Range(1, 101) >= 50)
                {
                    propSpawner.SpawnProp(gameObject.transform, PropChooser);
                }
                break;
            case 7:
            case 8:
                if (Random.Range(1, 101) >= 25)
                {
                    propSpawner.SpawnProp(gameObject.transform, PropChooser);
                }
                break;
            case 9:
            case 10:
                if (Random.Range(1, 101) >= 35)
                {
                    propSpawner.SpawnProp(gameObject.transform, PropChooser);
                }
                break;
            default:
                break;
        }
    }

    public void TakeDamage(float damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        hpSlider.value = (float)hp / totalHp;
        if (hp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffect, transform.position, transform.rotation);
        animator.CrossFade("Death", 0.1f);
        //Give Money
        GameManager.Instance.gameObject.GetComponent<BuildManager>().ChangeMoney(money);
        GameManager.Instance.gameObject.GetComponent<BuildManager>().ChangeScore(score);

        Destroy(effect, 1.5f);
        Destroy(this.gameObject);
    }

    private void MoveToNextWaypoint()
    {
        index++;
        if (index > positions.Length - 1)
        {
            ReachDestination();
        }
        
    }
}
