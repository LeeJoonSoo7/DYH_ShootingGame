using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void OnStartGameBTN()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitBTN()
    {
        Application.Quit();
    }
}
