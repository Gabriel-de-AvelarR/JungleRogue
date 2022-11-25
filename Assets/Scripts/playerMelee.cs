using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMelee : MonoBehaviour
{
    //public Animator animator;

    public LayerMask enemyLayers;

    public float pushForce;

    public float punchRange;
    public float punchDamage;

    public float kickRange;
    public float kickDamage;

    public float maxBlock = 3;

    public float ultRange;
    public float ultDamage;

    public bool isPunch = false;
    public bool isKick = false;
    public bool isBlock = false;
    public bool isUlt = false;
    public float timeUlt;

    //public Animator animationPlayer;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){

            Punch();

            Debug.Log("Socou");
        }

        if(Input.GetKeyDown(KeyCode.W)){
            Kick();
        }

        if(Input.GetKeyDown(KeyCode.E)){
            Block();
        }

        if(Input.GetKeyDown(KeyCode.R)){
            Ultimate();
        }

    }


    public void Punch(){
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, punchRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Enemy>().TakeDamage(punchDamage);
        }
        isPunch = true;
    }

    public void Kick(){
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, kickRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Enemy>().TakeDamage(kickDamage);
        }
        
        isKick = true;
    }

    public void Block(){
        isBlock = true;
    }

    public void Ultimate(){ 
        isUlt = true;

    }

    public void reset(){
        isPunch = false;
        isKick = false;
        isBlock = false;
        isUlt = false;
    }

    public void pushBack(Vector2 hitted, Vector2 hitter, Rigidbody2D rig){
        Vector2 difference = hitted - hitter;
        difference = difference * pushForce;
        rig.AddForce(difference, ForceMode2D.Impulse);

    }




}
