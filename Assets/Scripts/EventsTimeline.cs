using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventsTimeline : MonoBehaviour {
    public delegate void TimedAction();
    public int NumberEvents;
    public List<TimedEvent> Events;
    public List<bool> Conditions;
    int ActualEvent;
    // Use this for initialization
    void Start () {
        Events = new List<TimedEvent>(NumberEvents);
        Conditions = new List<bool>(NumberEvents);
        //Conditions[0] = true;
        ActualEvent = 0;

        foreach(TimedEvent t in Events)
        {
            t.OnEnd += ChangeEvent;
        }
        //Events[0].Start();
    }

    void ChangeEvent()
    {
        ActualEvent++;
        Events[ActualEvent].Start();
    }
	
	// Update is called once per frame
	void Update () {
        if(ActualEvent < Events.Count)
        {
            Events[ActualEvent].UpdateTime(Time.deltaTime);
        }
	}

    public void AddEvent(TimedEvent te)
    {
        Events.Add(te);
    }
}