using UnityEngine;
using System.Collections;

public class CanonScript : MonoBehaviour {
    public float duration, fromAngle, toAngle;
    public int EventIndexStart, EventIndexEnd;
    // Use this for initialization
    void Start () {
        //StartRotation();
        /*
        TimedEvent newEvent = new TimedEvent(duration);
        newEvent.OnStart += StartRotation;
        newEvent.OnEnd += StopRotation;
        FindObjectOfType<EventsTimeline>().AddEvent(newEvent);
        //FindObjectOfType<EventsTimeline>().Events[EventIndexStart].OnStart += StartRotation;
        //FindObjectOfType<EventsTimeline>().Events[EventIndexStart].OnEnd += StopRotation;
        FindObjectOfType<EventsTimeline>().Events[0].Start();
        */
    }

    void StartRotation()
    {
        StartCoroutine(ShootRotating());
    }

    void StopRotation()
    {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator ShootRotating()
    {
        GetComponent<ShootScript>().CanShoot = true;
        transform.rotation = Quaternion.Euler(0, 0, fromAngle);
        float time = 0;
        while(time <= duration)
        {
            time += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, fromAngle), Quaternion.Euler(0, 0, toAngle), time / duration);
            yield return new WaitForEndOfFrame();
        }
        // GetComponent<ShootScript>().CanShoot = false;
    }
}
