using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance;

    public Material foliageMat;

    private int eventsTriggered = 0;
    private bool moodSwitch;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        } 
        else
        {
            Instance = this;
        }
    }

    public void TriggerEvent()
    {
        eventsTriggered++;
        Debug.Log(eventsTriggered);
    }

    public bool EventLimit()
    {
        if(eventsTriggered == 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void MoodSwitched()
    {
        moodSwitch = true;
        Debug.Log("Mood switched");
        //foliageMat.SetFloat("_Wind_strength", 3.0f);
    }
}
