using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerVolume : MonoBehaviour
{
    public UnityEvent TriggerEntered;
    public UnityEvent TriggerExited;

    private void OnTriggerEnter(Collider other) {
        TriggerEntered.Invoke();
    }

    private void OnTriggerExit(Collider other) {
        TriggerExited.Invoke();
    }
}
