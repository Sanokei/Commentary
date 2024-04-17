using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

[RequireComponent(typeof(Rigidbody), typeof(Animator), typeof(BoxCollider))]
public class CommentaryNode : MonoBehaviour
{
    [SerializeField] Animator _NodeAnimator;
    [SerializeField] PlayableDirector _Dialogue;
    [SerializeField] Renderer _OutterNodeRenderer;

    public delegate void OnPlayableDirectorStopped(PlayableDirector director);
    public static event OnPlayableDirectorStopped OnPlayableDirectorStoppedEvent; 
    
    string _CurrentAnimationState = "Idle";
    bool _isPlaying = false;
    void SetAnimation(string ani)
    {
        SetAnimation(ani, _NodeAnimator);
    }
    void SetAnimation(string ani, Animator animator)
    {
        animator.SetBool(_CurrentAnimationState,false);
        _CurrentAnimationState = ani;
        animator.SetBool(ani,true);
    }
    void OnEnable()
    {
        _Dialogue.stopped += StopPlaying;
        PlayerInteract.OnCommentaryNodeHitEvent += OnRaycastHit;
    }
    void OnDisable()
    {
        _Dialogue.stopped -= StopPlaying;
        PlayerInteract.OnCommentaryNodeHitEvent -= OnRaycastHit;
    }
    
    void Awake()
    {
        SetAnimation("Idle");
        _OutterNodeRenderer.material.SetFloat("_Blend", 1);
    }
    
    void OnRaycastHit(RaycastHit hitdata)
    {
        if(!Input.GetKeyDown(KeyCode.E))
            return;
        // FIXME: this feels wrong, but its right???
        // can be improved with interface, but its good enough for now
        if(!hitdata.collider.gameObject.Equals(gameObject))
            return;
        if(!_isPlaying)
        {
            if(CommentaryNodeManager.Instance.PlayingCommentaryNode != null && !CommentaryNodeManager.Instance.PlayingCommentaryNode.Equals(this))
                CommentaryNodeManager.Instance.PlayingCommentaryNode.StopPlaying();
            StartPlaying();
        }
        else
        {
            StopPlaying();
        }
    }
    public void StartPlaying()
    {
        _isPlaying = true;
        SetAnimation("Playing");
        _Dialogue.Play();
        CommentaryNodeManager.Instance.PlayingCommentaryNode = this;
        _OutterNodeRenderer.material.SetFloat("_Blend", 0);
    }
    private void StopPlaying(PlayableDirector director)
    {
        // redundancy
        // It should never be any other playabledirector, take out check for optimization?
        if(director.Equals(_Dialogue))
            StopPlaying();
        OnPlayableDirectorStoppedEvent?.Invoke(director);
    }
    public void StopPlaying()
    {
        SetAnimation("Idle");
        _Dialogue.Stop();
        CommentaryNodeManager.Instance.PlayingCommentaryNode = null;
        _OutterNodeRenderer.material.SetFloat("_Blend", 1);
        _isPlaying = false;
    }
    // private void OnTriggerEnter2D(Collider2D playerCollider)
    // {
    //     _IsPlayerInRange = playerCollider.gameObject.CompareTag("Player");
    // }

    // private void OnTriggerExit2D(Collider2D playerCollider)
    // {
    //     _IsPlayerInRange = !playerCollider.gameObject.CompareTag("Player");
    // }
}