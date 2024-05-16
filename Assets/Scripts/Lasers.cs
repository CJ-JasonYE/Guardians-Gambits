using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
    //Res
    public GameObject firePoint;
    public Camera cam;
    public float maxLength;
    public GameObject[] laserPrefabs;
    public GameObject head;
    //
    private Ray rayMouse;
    private Vector3 direction;
    private Quaternion rotation;
    private RaycastHit hit;

    public int currentPrefab = 0;
    private GameObject laserInstance;
    private Hovl_Laser laserScript;
    private Hovl_Laser2 laserScript2;

    private void Start()
    {
    }

    private float cooldownTime = 1;
    private float cooldownTimer = 1;
    private bool laserEnabled = true;
    private bool calculateTime = false;
    // Update is called once per frame
    void Update()
    {
        print(cooldownTimer);
        if (calculateTime)
        {
            cooldownTimer -= Time.deltaTime;
        }
        if(laserEnabled)
        {
            //Enable lazer
            if (cooldownTimer > 0 && Input.GetMouseButtonDown(0))
            {
                calculateTime = true;
                Destroy(laserInstance);
                laserInstance = Instantiate(laserPrefabs[currentPrefab], firePoint.transform.position, firePoint.transform.rotation);
                laserInstance.transform.parent = transform;
                laserScript = laserInstance.GetComponent<Hovl_Laser>();
                laserScript2 = laserInstance.GetComponent<Hovl_Laser2>();

                //if (boxCollider == null)
                //{
                //    boxCollider = laserInstance.GetComponent<BoxCollider>();
                //}

                //Vector3 colliderSize = boxCollider.size;
                //colliderSize.z = hit.distance;
                //boxCollider.size = colliderSize;
                ////boxCollider.transform.position = transform.position + rayMouse.direction * (hit.distance / 2);
            }

            if (cooldownTimer <= 0)
            {
                laserEnabled = false;
                calculateTime = false;
                cooldownTimer = 0;
            }
            //Disable lazer prefab
            if (Input.GetMouseButtonUp(0))
            {
                calculateTime = false;
                if (laserScript) laserScript.DisablePrepare();
                if (laserScript2) laserScript2.DisablePrepare();
                Destroy(laserInstance, 1);
            }
        }
        else
        {
            print("enter not enable");
            if (cooldownTimer <= 0)
            {
                if (laserScript) laserScript.DisablePrepare();
                if (laserScript2) laserScript2.DisablePrepare();
                Destroy(laserInstance, 1);
                cooldownTimer += Time.deltaTime;
            }
            cooldownTimer += Time.deltaTime;
            print("+ once");
            if (cooldownTimer >= cooldownTime)
            {
                cooldownTimer = cooldownTime;
                laserEnabled = true;
            }
        }
        

        //Current fire point
        if (cam != null)
        {
            var mousePos = Input.mousePosition;
            rayMouse = cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, maxLength)) // can add layer mask to interact only with enemy or walls
            {
                Vector3 offset = new Vector3(0, firePoint.transform.position.y, 0);
                Vector3 actualPoint = hit.point - offset;
                //RotateToMouseDirection(head, hit.point);
                RotateToMouseDirection(head, hit.point);
                //LaserEndPoint = hit.point;
                //Debug.Log(mousePos);
            }
            else
            {
                var pos = rayMouse.GetPoint(maxLength);
                RotateToMouseDirection(head, pos);
                //LaserEndPoint = pos;
            }
            
        }
        else
        {
            Debug.Log("No camera");
        }
    }

    //rotate the firepoint
    void RotateToMouseDirection(GameObject go, Vector3 hitpoint)
    {
        direction = hitpoint- go.transform.position;
        rotation = Quaternion.LookRotation(direction); // calcuate the quaternion that firepoint need to face
        Vector3 temp = rotation.eulerAngles;
        rotation = Quaternion.Euler(0, temp.y, 0);
        go.transform.localRotation = Quaternion.Lerp(go.transform.rotation, rotation, 1);
    }

    private void DisableLaser()
    {

    }
}
