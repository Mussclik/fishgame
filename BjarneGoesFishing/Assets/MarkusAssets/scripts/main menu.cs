using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;







public class mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerInfo.maxDepth = 49;
        SceneManager.LoadSceneAsync(3); 
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }



}
