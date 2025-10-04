using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatScene : MonoBehaviour
{
    // �й� ȭ�鿡�� Time.timeScale=0 �ߴٸ� �ε� ���� �� 1��
    void ResumeTime() => Time.timeScale = 1f;

    public void GoPlayMap()
    {
        ResumeTime();
        SceneManager.LoadScene("Play Map");   // ��Ȯ�� �� �̸�
    }

    public void GoMainMenu()
    {
        ResumeTime();
        SceneManager.LoadScene("MainMenu");   // ��Ȯ�� �� �̸�
    }
}
