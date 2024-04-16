using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DontDestroyHelper : MonoBehaviour
{
    [SerializeField] int _TotalNotDestroyable;
    int _NotDestroyableCount;

    public delegate void NotDestroyedHelper();
    public static event NotDestroyedHelper NotDestroyedHelperEvent; 

    bool _calledHelperEvent = false;
    void OnEnable()
    {
        DontDestroyOnLoadObject.NotDestroyedEvent += AddToCounter;
    }

    void OnDisable()
    {
        DontDestroyOnLoadObject.NotDestroyedEvent -= AddToCounter;
    }

    void AddToCounter()
    {
        _NotDestroyableCount++;
    }

    // void Start

    void Update()
    {
        if(!_calledHelperEvent && _TotalNotDestroyable == _NotDestroyableCount)
        {
            NotDestroyedHelperEvent?.Invoke();
            _calledHelperEvent = true;
        }
    }
}
