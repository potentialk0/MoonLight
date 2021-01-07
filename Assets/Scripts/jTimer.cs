using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class jTimer
{
    static float timeElapsed = 0.0f;
    static float timebase;

    static bool isTime = false;


    public static bool SetTimer(float time)
	{
        timeElapsed += Time.deltaTime;
        timebase = time;

        if(timeElapsed >= timebase)
		{
            isTime = true;
		}
        return isTime;
	}

    public static void ResetTimer()
	{
        timeElapsed = 0.0f;
        isTime = false;
	}
}
