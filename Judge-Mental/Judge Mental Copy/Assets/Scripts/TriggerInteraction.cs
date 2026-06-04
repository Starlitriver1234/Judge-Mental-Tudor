using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerInteraction : MonoBehaviour
{
    public UnityEvent enteredTrigger, exitedTrigger;

    private void OnTriggerEnter(Collider other)
    {
        enteredTrigger.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        exitedTrigger.Invoke();
    }
}
