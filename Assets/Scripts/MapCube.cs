using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour {
    [HideInInspector]
    public GameObject turretGo;//保存当前cube身上的炮台
    [HideInInspector]
    public TurretData turretData;
    [HideInInspector]
    public bool isUpgraded = false;

    public GameObject buildEffect;

    private Renderer renderer;

    public BuiltTurretData builtTurretData;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    public void BuildTurret(TurretData turretData)
    {
        turretData.Upgraded = false;
        this.turretData = turretData;
        isUpgraded = false;
        turretGo = GameObject.Instantiate(turretData.turretPrefab, transform.position, Quaternion.identity);
        switch (turretData.type)
        {
            case TurretType.LaserTurret:
                builtTurretData.AddLTurret(turretGo);
                break;
            case TurretType.MissileTurret:
                builtTurretData.AddMTurret(turretGo);
                break;
            case TurretType.CannonTurret:
                builtTurretData.AddCTurret(turretGo);
                break;
            default:
                break;
        }
        if (turretGo.GetComponentInChildren<Lasers>() != null)
        {
            turretGo.GetComponentInChildren<Lasers>().cam = Camera.main;
        }
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }

    public void UpgradeTurret()
    {
        if(isUpgraded==true)return;

        Destroy(turretGo);
        isUpgraded = true;
        turretData.Upgraded = true;
        turretGo = GameObject.Instantiate(turretData.turretUpgradedPrefab, transform.position, Quaternion.identity);
        if (turretGo.GetComponentInChildren<Lasers>() != null)
        {
            turretGo.GetComponentInChildren<Lasers>().cam = Camera.main;
        }
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }
    
    public void DestroyTurret()
    {
        Destroy(turretGo);
        isUpgraded = false;
        turretGo = null;
        turretData=null;
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }

    void OnMouseEnter()
    {
        if (turretGo == null && EventSystem.current.IsPointerOverGameObject()==false)
        {
            renderer.material.color = Color.green;
            //print("ShowRed");
        }
    }
    void OnMouseExit()
    {
        renderer.material.color = Color.clear;
    }
}
