using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour 
{

    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData cannonTurretData;

    //current Selected TurretData
    private TurretData selectedTurretData;
    //current Selected Turret
    private MapCube selectedMapCube;

    public Text moneyText;

    public Animator moneyAnimator;

    private int money = 150;

    public Text scoreText;

    private int score = 0;

    public GameObject upgradeCanvas;

    private Animator upgradeCanvasAnimator;

    public Button buttonUpgrade;

    public Toggle laserToggle;
    public Toggle missileToggle;
    public Toggle cannonToggle;

    //public Camera cam;

    public void ChangeMoney(int change=0)
    {
        money += change;
        moneyText.text = "$" + money;
    }

    public void ChangeScore(int change=0)
    {
        score += change;
        scoreText.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    void Start()
    {
        upgradeCanvasAnimator = upgradeCanvas.GetComponent<Animator>();
        ChangeMoney();
        ChangeScore();
    }

    void Update()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()==false)
            {
                //开发炮台的建造
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray,out hit, 1000, LayerMask.GetMask("MapCube"));
                if (isCollider)
                {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();
                    if (selectedTurretData != null && mapCube.turretGo == null)
                    {
                        //Can Create Turret
                        if (money >= selectedTurretData.cost)
                        {
                            ChangeMoney(-selectedTurretData.cost);
                            mapCube.BuildTurret(selectedTurretData);
                            if (selectedTurretData.type == TurretType.LaserTurret)
                            {
                                laserToggle.isOn = false;
                            }
                            else if(selectedTurretData.type == TurretType.MissileTurret)
                            {
                                missileToggle.isOn = false;
                            }
                            else
                            {
                                cannonToggle.isOn = false;
                            }
                            selectedTurretData = null;
                        }
                        else
                        {
                            //Money is not enough
                            moneyAnimator.SetTrigger("Flicker");
                            if (selectedTurretData.type == TurretType.LaserTurret)
                            {
                                laserToggle.isOn = false;
                            }
                            else if (selectedTurretData.type == TurretType.MissileTurret)
                            {
                                missileToggle.isOn = false;
                            }
                            else
                            {
                                cannonToggle.isOn = false;
                            }
                            selectedTurretData = null;
                        }
                    }
                    else if (mapCube.turretGo != null)
                    {
                        
                        // Upgrade
                        
                        //if (mapCube.isUpgraded)
                        //{
                        //    ShowUpgradeUI(mapCube.transform.position, true);
                        //}
                        //else
                        //{
                        //    ShowUpgradeUI(mapCube.transform.position, false);
                        //}
                        if (mapCube == selectedMapCube && upgradeCanvas.activeInHierarchy)
                        {
                            StartCoroutine(HideUpgradeUI());
                        }
                        else
                        {
                            ShowUpgradeUI(mapCube.transform.position, mapCube.isUpgraded);
                        }
                            selectedMapCube = mapCube;
                    }

                }
            }
        }
    }

    public void OnLaserSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = laserTurretData;
            //selectedTurretData.turretPrefab.GetComponentInChildren<Lasers>().cam = cam;
        }
    }

    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = missileTurretData;
        }
    }
    public void OnStandardSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = cannonTurretData;
        }
    }

    void ShowUpgradeUI(Vector3 pos, bool isDisableUpgrade=false)
    {
        StopCoroutine("HideUpgradeUI");
        upgradeCanvas.SetActive(false);
        upgradeCanvas.SetActive(true);
        upgradeCanvas.transform.position = pos;
        buttonUpgrade.interactable = !isDisableUpgrade;
    }

    IEnumerator HideUpgradeUI()
    {
        upgradeCanvasAnimator.SetTrigger("Hide");
        //upgradeCanvas.SetActive(false);
        yield return new WaitForSeconds(0.8f);
        upgradeCanvas.SetActive(false);
    }

    public void OnUpgradeButtonDown()
    {
        if (money >= selectedMapCube.turretData.costUpgraded)
        {
            ChangeMoney(-selectedMapCube.turretData.costUpgraded);
            selectedMapCube.UpgradeTurret();
        }
        else
        {
            moneyAnimator.SetTrigger("Flicker");
        }

        StartCoroutine(HideUpgradeUI());
    }
    public void OnDestroyButtonDown()
    {
        if (selectedMapCube.isUpgraded)
        {
            ChangeMoney((int)((selectedMapCube.turretData.cost + selectedMapCube.turretData.costUpgraded) * 0.5f));
        }
        else
        {
            ChangeMoney((int)(selectedMapCube.turretData.cost * 0.5f));
        }
        selectedMapCube.DestroyTurret();
        StartCoroutine(HideUpgradeUI());
    }
    
}
