using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowReticle : MonoBehaviour
{
    [SerializeField] Image _Reticle;
    [SerializeField] bool _ShowReticle;
    void OnEnable()
    {
        PlayerInteract.OnCommentaryNodeHitEvent += SetReticleTrue;
    }
    void OnDisable()
    {
        PlayerInteract.OnCommentaryNodeHitEvent -= SetReticleTrue;
    }
    void SetReticleTrue(RaycastHit hitData)
    {
        _ShowReticle = true;
    }
    void Update()
    {
        if(_ShowReticle)
        {
            _Reticle.color = new Color(255,255,255,255);
        }
        else
        {
            _Reticle.color = new Color(0,0,0,0);
        }
        _ShowReticle = false;
    }
}
