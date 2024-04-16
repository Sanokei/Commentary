using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentaryNodeManager : MonoBehaviour
{
    public static CommentaryNodeManager Instance{get;private set;}
    public CommentaryNode PlayingCommentaryNode;
    
    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}