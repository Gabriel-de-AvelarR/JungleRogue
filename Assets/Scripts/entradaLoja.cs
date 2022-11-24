using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class entradaLoja : MonoBehaviour
{
    private Rigidbody2D rig;

    void Start(){
      rig = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision){
      if((collision.gameObject.tag == "Player")){
        SceneManager.LoadScene("Loja");
      }
    }
  }
