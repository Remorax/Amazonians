using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSounds : MonoBehaviour
{
    // Start is called before the first frame update
   	public float frameNumber = 0;
    public int frequency = 2000;
    public AudioSource MusicSource;

    public void forestSound()
    {
    	MusicSource.clip = Resources.Load<AudioClip>("forest2");
    	MusicSource.volume = 0.7f;
    	MusicSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (frameNumber % frequency == 0){
        	forestSound();
    	}
    	frameNumber += 1;

    }
}
