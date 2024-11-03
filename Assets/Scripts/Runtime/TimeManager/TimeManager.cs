using UnityEngine;

public static class TimeManager
{
	public static void PauseTime()
	{
		Time.timeScale = 0;
	}

	public static void ResumeTime()
	{
		Time.timeScale = 1;
	}
}
