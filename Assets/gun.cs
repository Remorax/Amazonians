using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage = 10.0f;
    public float range = 100.0f;

    public Camera fpsCam;
    public ParticleSystem MuzzleFlash;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
        	Shoot();
        }

    }

    void Shoot()
    {
    	// MuzzleFlash.transform.position = Input.mousePosition;
    	MuzzleFlash.Play();
    	RaycastHit hit;
    	if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
    	{
    		Target target = hit.transform.GetComponent<Target>();
    		if (target) {
    			target.TakeDamage(damage);
    		}

	   	}
    }
}
