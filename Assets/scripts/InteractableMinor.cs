using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMinor : MonoBehaviour
{
    private bool inRange;
    private bool eventTriggered;
    public GameObject ParticleEffect;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e"))
        {
            if(inRange && eventTriggered == false)
            {
                Singleton.Instance.TriggerEvent();
                eventTriggered = true;
                Debug.Log("Triggered");
                ParticleEffect.SetActive(true);
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
