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
    public AudioSource MusicSource;
    public BossControls boss;
//    public videoplay VideoPlayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !PauseMenu.GameIsPaused){
        	Shoot();
        }

    }

	public void gunfire()
    {
    	MusicSource.clip = Resources.Load<AudioClip>("MachineGun");
    	MusicSource.volume = 0.05f;
    	MusicSource.Play();
    }

    void Shoot()
    {
    	// MuzzleFlash.transform.position = Input.mousePosition;
    	MuzzleFlash.Play();
    	RaycastHit hit;
    	gunfire();
        if (Mathf.Abs(Vector3.Angle(boss.transform.position - transform.position, transform.forward)) < 20)
        {

			boss.TakeDamage(damage);
	   	}
        //VideoPlayer.PlayVideo();
//        VideoPlayer = FindObjectOfType<videoplay>();
//        StartCoroutine(VideoPlayer.PlayVideo());

    }
}
