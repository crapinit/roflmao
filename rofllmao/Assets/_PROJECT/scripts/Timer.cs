using UnityEngine;
using System.Collections;
using System.Threading;

public class Timer : MonoBehaviour
{
	public float Totaltimeleft;
	public float timeleft;
	float ticktime;
	public int ticks;
	public int maxticks;
	public bool running;
	public int Id;
	System.Action action = null;
	System.Func<bool> condition = null;
	private float i, t;
	//Sets the timer with an interval specified in seconds, amount of ticks, method to call
	//Also starts the timer
	//Don't forget to add the timer as a component to a GameObject in order for it to work
	public void SetTimer(float Interval, int Ticks, System.Action Action = null, System.Func<bool> Condition = null)
	{
		i = Interval;
		t = Ticks;
		Totaltimeleft = Interval * Ticks;
		timeleft = Interval;
		ticktime = Interval;
		maxticks = Ticks != 0 ? Ticks : int.MaxValue;
		running = true;
		action = Action;
		condition = Condition;
	}

	public void PauseTimer()
	{
		running = false;
	}

	public void StopTimer()
	{
		running = false;
		timeleft = ticktime;
		ticks = 0;
		Totaltimeleft = i*t;
	}

	public void StartTimer()
	{
		running = true;
	}


	// Update is called once per frame
	void Update()
	{

		if (running)
		{
			timeleft -= Time.deltaTime;
			Totaltimeleft -= Time.deltaTime;
			if (timeleft <= 0)
			{
				ticks++;
				if (condition != null) running = condition();
				timeleft = ticktime;
				if (action != null) action();
			}
		}
		if (ticks >= maxticks) StopTimer();
	}
}  