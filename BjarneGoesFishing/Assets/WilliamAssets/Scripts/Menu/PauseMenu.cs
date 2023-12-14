using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0f;
    }
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Unpause()
    {
        gameObject.SetActive(false);
    }
}
