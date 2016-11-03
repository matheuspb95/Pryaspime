using UnityEngine;
using System.Collections.Generic;

public class MusicProgression : MonoBehaviour {
    SoundController MusicParts;
    public List<string> PartsHash;
    int ActualPart;
	// Use this for initialization
	void Start () {
        ActualPart = 0;
        MusicParts = GetComponent<SoundController>();
        EventsTimeline.Events[0].OnStart += PlayActuaPart;
        EventsTimeline.Events[0].OnEnd += NextPart;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NextPart()
    {
        ActualPart++;
        PlayActuaPart();
    }

    public void PlayActuaPart()    {

        MusicParts.PlaySound(PartsHash[ActualPart]);
    }
}
