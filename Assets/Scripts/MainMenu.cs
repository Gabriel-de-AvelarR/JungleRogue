using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{
  
    public void PlayGame() {  
        SceneManager.LoadScene("Level1");  
    }  


    public void OpenConfig(){
        SceneManager.LoadScene("Config");
    }

    public void End(){
        Application.Quit();
    }
}
