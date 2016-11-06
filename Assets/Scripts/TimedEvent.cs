using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class TimedEvent
{
        public delegate void onStart();
        public onStart OnStart;
        public delegate void onEnd();
        public onEnd OnEnd;
        float duration, time;

        public TimedEvent(float duration)
        {
        this.duration = duration;
        }

        public void Start()
        {
            OnStart();
        }

        public void UpdateTime(float deltaTime)
        {
            time += deltaTime;
            if(time <= duration)
            {
                End();
            }
        }

        public void End()
        {
            OnEnd();
        }
}

