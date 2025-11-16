using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerInteraction : MonoBehaviour
{
    public UnityEvent enteredTrigger, exitedTrigger;

    private void OnTriggerEnter2D(Collider other)
    {
        enteredTrigger.Invoke();
    }

    private void OnTriggerExit2D(Collider other)
    {
        exitedTrigger.Invoke();
    }
}
