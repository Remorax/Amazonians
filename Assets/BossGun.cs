using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage = 10.0f;
    public float range = 100.0f;

    public GameObject boss;
    public ParticleSystem MuzzleFlash;
    public AudioSource MusicSource;

    //    public videoplay VideoPlayer;

    // Update is called once per frame
    void Update()
    {
       
    }

    public void gunfire()
    {
        MusicSource.clip = Resources.Load<AudioClip>("MachineGun");
        MusicSource.volume = 0.05f;
        MusicSource.Play();
    }

    public void Shoot()
    {
        // MuzzleFlash.transform.position = Input.mousePosition;
        MuzzleFlash.Play();
        RaycastHit hit;
        gunfire();

        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Movement target = hit.transform.GetComponent<Movement>();

            if (target)

            {
                Debug.LogWarning("Aaaa");
                target.TakeDamage(damage);
            }
        }
        //VideoPlayer.PlayVideo();
        //        VideoPlayer = FindObjectOfType<videoplay>();
        //        StartCoroutine(VideoPlayer.PlayVideo());

    }
}
