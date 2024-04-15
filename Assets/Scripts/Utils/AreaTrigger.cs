using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public delegate void OnEnterExit(string name);
    public static event OnEnterExit OnEnterEvent;
    public static event OnEnterExit OnExitEvent;
    private void OnTriggerEnter(Collider other)
    {
        OnEnterEvent?.Invoke(gameObject.name);
    }
    private void OnTriggerExit(Collider other)
    {
        OnExitEvent?.Invoke(gameObject.name);
    }
}
