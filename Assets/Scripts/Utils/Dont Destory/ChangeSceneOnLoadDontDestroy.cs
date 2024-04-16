using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnLoadDontDestroy : MonoBehaviour
{
    public static ChangeSceneOnLoadDontDestroy Instance {get; private set;}
    [SerializeField] string _SceneName;
    void OnEnable()
    {
        DontDestroyHelper.NotDestroyedHelperEvent += NextScene;
    }
    void OnDisable()
    {
        DontDestroyHelper.NotDestroyedHelperEvent -= NextScene;
    }
    void Awake()
    {
        if (!Instance)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(_SceneName);
    }
}
