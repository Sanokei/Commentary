using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    string Name;
    public void LoadSceneMode(string name)
    {
        this.Name = name;
        SceneManager.LoadScene(name);
    }
}
