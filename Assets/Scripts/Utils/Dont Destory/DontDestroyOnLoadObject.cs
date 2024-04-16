using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadObject : MonoBehaviour
{
    public delegate void NotDestroyed();
    public static event NotDestroyed NotDestroyedEvent;
    void Start()
    {
        NotDestroyedEvent?.Invoke();
        DontDestroyOnLoad(gameObject);
    }
}