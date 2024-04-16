using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class SubtitlesManager : MonoBehaviour
{
    [SerializeField] TMP_Text subText;
    void OnEnable()
    {
        CommentaryNode.OnPlayableDirectorStoppedEvent += OnPlayableDirectorStopped;
    }

    void OnDisable()
    {
        CommentaryNode.OnPlayableDirectorStoppedEvent -= OnPlayableDirectorStopped;
    }
    void OnPlayableDirectorStopped(PlayableDirector director)
    {
        ResetSubtitles();
    }
    public void ResetSubtitles()
    {
        subText.text = "";
    }
    public void SetSubtitles(string s)
    {
        subText.text = s;
    }
}
