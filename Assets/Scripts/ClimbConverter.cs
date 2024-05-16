using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbConverter : MonoBehaviour
{
    private PlayerMovement player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerMovement>();
            player.currentTurret = this.GetComponentInParent<PrimitiveTurret>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.currentTurret = null;
            player = null;
        }
    }
}
