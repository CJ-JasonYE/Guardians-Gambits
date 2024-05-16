using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    public float walkspeed = 5;
    private float horizontal;
    private float vertical;
    private Vector2 movement;
    private float rotationDegreePerSecond = 1000;

    public PrimitiveTurret currentTurret;
    private bool isClimbbed = false;
    private float idleTimer = 0;

    //
    private string currentAnimation = "";
    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeAnimation("Idle2");
    }

    void FixedUpdate()
    {
        if (animator)
        {
            Vector3 stickDirection = new Vector3(horizontal, 0, vertical);
            if (stickDirection.sqrMagnitude > 1) stickDirection.Normalize();
            float speedOut=stickDirection.sqrMagnitude;

            if (stickDirection != Vector3.zero)
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(stickDirection, Vector3.up), rotationDegreePerSecond * Time.deltaTime);
            GetComponent<Rigidbody>().velocity = transform.forward * speedOut * walkspeed + new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0);
        }
    }

    void Update()
    {
        if (!isClimbbed)
        {
            PlayerInput();
            CheckAnimation();
            if (movement == Vector2.zero)
            {
                idleTimer += Time.deltaTime;
                if (idleTimer > 3)
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                }
            }
            else
            {
                idleTimer = 0;
                transform.GetChild(2).gameObject.SetActive(false);

            }
        }
        
        ClimbOnTower();
    }

    void PlayerInput()
    {
        //walk
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2(horizontal, vertical);
    }

    void ClimbOnTower()
    {
        if (currentTurret!=null)
        {
            if (!isClimbbed)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    isClimbbed = true;
                    //LaserTurret
                    if (currentTurret.GetComponentInChildren<Lasers>()!=null)
                    {
                        currentTurret.transform.GetChild(3).gameObject.SetActive(false);
                        currentTurret.GetComponent<LaserTurret>().laserRenderer.enabled = false;
                        currentTurret.GetComponent<LaserTurret>().enabled = false;
                        currentTurret.GetComponentInChildren<Lasers>().enabled = true;
                        gameObject.transform.SetParent(currentTurret.transform.GetChild(4));
                        gameObject.transform.localPosition = Vector3.zero;
                        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    }
                    //MissileTurret
                    if (currentTurret.GetComponent<MissileTurret>() != null)
                    {
                        currentTurret.GetComponent<MissileTurret>().playerMode = true;
                        gameObject.transform.SetParent(currentTurret.transform.GetChild(2));
                        gameObject.transform.localPosition = Vector3.zero;
                        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    }
                    //CannonTurret
                    if (currentTurret.GetComponent<CannonTurret>() != null)
                    {
                        currentTurret.GetComponent<CannonTurret>().playerMode = true;
                        gameObject.transform.SetParent(currentTurret.transform.GetChild(2));
                        gameObject.transform.localPosition = Vector3.zero;
                        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    isClimbbed = false;
                    //LaserTurret
                    if (currentTurret.GetComponentInChildren<Lasers>()!=null)
                    {
                        currentTurret.GetComponent<LaserTurret>().enabled = true;
                        currentTurret.transform.GetChild(3).gameObject.SetActive(true);
                        currentTurret.GetComponent<LaserTurret>().laserRenderer.enabled = true;
                        currentTurret.GetComponentInChildren<Lasers>().enabled = false;
                        gameObject.transform.SetParent(null);
                    }
                    //MissileTurret
                    if (currentTurret.GetComponent<MissileTurret>() != null)
                    {
                        currentTurret.GetComponent<MissileTurret>().playerMode = false;
                        gameObject.transform.SetParent(null);
                    }
                    //CannonTurret
                    if (currentTurret.GetComponent<CannonTurret>() != null)
                    {
                        currentTurret.GetComponent<CannonTurret>().playerMode = false;
                        gameObject.transform.SetParent(null);
                    }
                    this.transform.position = new Vector3(transform.position.x,transform.position.y-2f,transform.position.z) ;
                }
            }
        }
    }

    private void CheckAnimation()
    {
        if (movement.y == 1)
        {
            ChangeAnimation("RunForward");
        }
        else if (movement.y == -1)
        {
            ChangeAnimation("RunForward");
        }
        else if (movement.x == 1)
        {
            ChangeAnimation("RunLeft");
        }
        else if (movement.x == -1)
        {
            ChangeAnimation("RunLeft");
        }
        else
        {
            ChangeAnimation("Idle1");
        }
    }
    private void ChangeAnimation(string animation, float crossfade = 0.2f)
    {
        if(currentAnimation != animation)
        {
            currentAnimation = animation;
            animator.CrossFade(currentAnimation, crossfade);
        }
    }
}
