using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public void SceneLoad(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void GameExit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
