using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;







public class mainmenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;

    public void PlayGame()
    {
        PlayerInfo.maxDepth = 49;
        SceneManager.LoadSceneAsync(3); 
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }
    public void CloseCredits()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }



}
