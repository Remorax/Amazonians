using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip soundClip;
    public AudioSource MusicSource;
    public float frameNumber = 0;
    public int frequency = 200;
    void Start()
    {
        // MusicSource.clip = soundClip;
        MusicSource.GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
    	if (frameNumber % frequency == 0){
        	MusicSource.Play();
    	}
    	frameNumber += 1;
    }

    public void normalElephantSound()
    {
    	MusicSource.clip = Resources.Load<AudioClip>("Elephant_sound");
    	MusicSource.Play();
    }

    public void painedElephantSound()
    {
    	MusicSource.clip = Resources.Load<AudioClip>("elephant_pained");
    	MusicSource.Play();
    }
}
