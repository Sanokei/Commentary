using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

public class TriggerNode : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] Animator _VisualCue;
    public string CurrentAnimationState = "Idle";
    [SerializeField] PlayableDirector _Dialogue;
    [SerializeField] Camera _Camera;
    
    // FIXME: FLAG
    bool _isPlaying = false;
    void SetAnimation(string ani)
    {
        SetAnimation(ani, _VisualCue);
    }
    void SetAnimation(string ani, Animator animator)
    {
        animator.SetBool(CurrentAnimationState,false);
        CurrentAnimationState = ani;
        animator.SetBool(ani,true);
    }
    private void Awake()
    {
        SetAnimation("Idle");
    }
    RaycastHit hitData;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(_Camera.ScreenPointToRay(Input.mousePosition), out hitData, 5) && hitData.transform.tag == "CommentaryNode")
            {
                if(!_isPlaying)
                {
                    SetAnimation("Playing");
                    _Dialogue.Play();
                }
                else
                {
                    SetAnimation("Idle");
                    _Dialogue.Stop();
                }
            }
        }
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