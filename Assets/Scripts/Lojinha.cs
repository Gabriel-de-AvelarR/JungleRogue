using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lojinha : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Picanga(){

    }

    public void Chave(){

    }

    public void Voltar(){
        Debug.Log("Clicou");
        SceneManager.LoadScene("Levels/Level1");
    }
}
