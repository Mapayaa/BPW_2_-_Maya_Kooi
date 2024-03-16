using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMajor : MonoBehaviour
{
    private bool inRange;
    private bool eventTriggered;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (inRange && eventTriggered == false && Singleton.Instance.EventLimit())
            {
                Singleton.Instance.MoodSwitched();
                eventTriggered = true;
                Debug.Log("Triggered");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
