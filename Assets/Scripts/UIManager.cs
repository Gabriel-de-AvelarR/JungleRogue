using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] Hearts;
    public int life;

    void Start(){
        //inicialmente o jogador tem apenas 3 vidas
        Hearts[3].SetActive(false);
        Hearts[4].SetActive(false);
        Hearts[5].SetActive(false);
    }

    // Start is called before the first frame update
    public void reduceHearts(float update, float maxHealth){
        update--;
        maxHealth--;
        while(maxHealth > update && maxHealth >= 0){
            int Postion = (int) maxHealth;
            Hearts[Postion].SetActive(false);
            maxHealth--;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
