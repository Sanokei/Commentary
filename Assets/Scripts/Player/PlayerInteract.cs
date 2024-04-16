using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public delegate void OnCommentaryNodeHit(RaycastHit hitData);
    public static event OnCommentaryNodeHit OnCommentaryNodeHitEvent; 
    
    [SerializeField] Camera _Camera;
    RaycastHit hitData;
    void Update()
    {
        // TODO: Make it changable with settings
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(_Camera.ScreenPointToRay(Input.mousePosition), out hitData, 5) && hitData.transform.tag == "Commentary")
            {
                OnCommentaryNodeHitEvent?.Invoke(hitData);
            }
        }
    }
}
