using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50.0f;
    public AudioClip soundClip;
    public AudioSource MusicSource1, MusicSource2;
    public float frameNumber = 0;
    public int frequency = 200;

    void Update()
    {
    	if (frameNumber % frequency == 0){
        	normalElephantSound();
    	}
    	frameNumber += 1;
    }


    public void normalElephantSound()
    {
    	MusicSource1.clip = Resources.Load<AudioClip>("Elephant_sound");
    	MusicSource1.volume = 0.1f;
    	MusicSource1.Play();
    }

    public void painedElephantSound()
    {
    	MusicSource2.clip = Resources.Load<AudioClip>("elephant_pained");
    	MusicSource2.volume = 1.0f;
    	MusicSource1.Stop();
    	MusicSource2.Play();
    }

    public void TakeDamage(float amount) 
    {
        health -= amount;
        painedElephantSound();
        if (health<=0f){
            Destroy(gameObject);
            //Debug.LogWarning(GameObject.FindGameObjectWithTag("VideoPlayer"));
            //gameObject = GameObject.FindGameObjectWithTag("VideoPlayer").GetComponent<videoplay>;
            //gameObject.PlayVideo();
        }
    }
}
