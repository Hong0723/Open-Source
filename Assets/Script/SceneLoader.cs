using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{
    public void LoadPlayMap()
    {
        SceneManager.LoadScene("Play Map");  // Map �� �̸��� �����ϰ�
    }
}
