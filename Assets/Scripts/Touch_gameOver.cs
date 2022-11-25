using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Touch_gameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public void reiniciaClick(){
        SceneManager.LoadScene("Level1");
    }

    public void fechaAplicação(){
        SceneManager.LoadScene("Menu");
    }
}
