using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
	#region Fields

	float totalSeconds = 0;

	float elapsedSeconds = 0;
	bool running = false;
	int previousCountdownValue;

	bool started = false;

	TimerFinishedEvent timerFinishedEvent = new TimerFinishedEvent();

	#endregion

	#region Properties

	public float Duration
    {
		set
        {
			if (!running)
            {
				totalSeconds = value;
			}
		}
	}

	public bool Finished
    {
		get { return started && !running; } 
	}

	public bool Running
    {
		get { return running; }
	}

    #endregion

    #region Public methods

  
  
  
    void Update()
    {

		if (running)
        {
			elapsedSeconds += Time.deltaTime;

			if (elapsedSeconds >= totalSeconds)
            {
				running = false;
				timerFinishedEvent.Invoke();
			}
		}
	}

	public void Run()
    {

		if (totalSeconds > 0)
        {
			started = true;
			running = true;
			elapsedSeconds = 0;
		}
	}

	public void Stop()
    {
		started = false;
		running = false;
	}

	public void AddTimerFinishedEventListener(UnityAction handler)
    {
		timerFinishedEvent.AddListener(handler);
	}

	#endregion
}
