using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startButtonClicked : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("DubleBufferPatternLoadingScene");
    }
        
}
