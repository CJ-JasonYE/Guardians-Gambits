using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USPrtclDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Erase());
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ParticleSystem>().isPlaying == false)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator Erase()
    {
        yield return new WaitForSeconds(0.85f);
        this.GetComponent<ParticleSystem>().Stop();
        //Destroy(this.gameObject);
    }
}
