using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitlesManager : MonoBehaviour
{
    [SerializeField] TMP_Text subText;
    public void SetSubtitles(string s)
    {
        subText.text = s;
    }
}
