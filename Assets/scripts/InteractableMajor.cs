using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InteractableMajor : MonoBehaviour
{
    private bool inRange;
    private bool eventTriggered;
     public GameObject BeforeGlobalVolume; // Assign this in the Inspector
    public GameObject AfterGlobalVolume; // Assign this in the Inspector

 void Start()
    {
        // Ensure the initial global volume is enabled and the new global volume is disabled at the start
        if (BeforeGlobalVolume != null)
        {
            BeforeGlobalVolume.SetActive(true);
        }

        if (AfterGlobalVolume != null)
        {
            AfterGlobalVolume.SetActive(false);
        }
    }
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
                SwitchVolumes();
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
     void SwitchVolumes()
    {
        if (BeforeGlobalVolume == null || AfterGlobalVolume == null)
        {
            Debug.LogError("One or both global volumes are not assigned.");
            return;
        }

        // Disable the initial global volume
        BeforeGlobalVolume.SetActive(false);

        // Enable the new global volume
        AfterGlobalVolume.SetActive(true);

        Debug.Log("Switched global volumes.");
    }
}
