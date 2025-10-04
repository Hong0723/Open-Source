using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene: MonoBehaviour
{
    public void GoPlayMap()
    {
        SceneManager.LoadScene("Play Map");  // Map �� �̸��� �����ϰ�
    }

    public void GoLogin()
    {
        SceneManager.LoadScene("Login");  // Map �� �̸��� �����ϰ�
    }
}
