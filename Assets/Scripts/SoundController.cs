using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundController : MonoBehaviour {
    public Dictionary<string, AudioSource> Sounds;
    // Use this for initialization
    void Start () {
        Sounds = new Dictionary<string, AudioSource>();

        foreach (AudioSource audio in GetComponents<AudioSource>())
        {
            Debug.Log(audio.clip.name);
            Sounds.Add(audio.clip.name, audio);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlaySound(string sound)
    {
        Sounds[sound].Play();
    }
}
