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
    public bool isBlock = false;

    public float ultRange;
    public float ultDamage;
    public bool isUlt;
    public float timeUlt;


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
            StartCoroutine(Block());
        }

        if(Input.GetKeyDown(KeyCode.R)){
            Ultimate();
        }

        //checa Timers
        //desativa Timers 

    }


    public void Punch(){
        //animator.SetTrigger("Punch");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, punchRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Enemy>().TakeDamage(punchDamage);
        }
    }

    public void Kick(){
        //animator.SetTrigger("Kick");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, kickRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Enemy>().TakeDamage(kickDamage);
        }
    }

    public IEnumerator Block(){
        //animator.SetTrigger("Block");
        isBlock = true;
        yield return new WaitForSeconds(2);
        isBlock = false;
    }

    public void Ultimate(){
        //animator.SetTrigger("Ult");
        isUlt = true;

        //set Timer
    }

    public void pushBack(Vector2 hitted, Vector2 hitter, Rigidbody2D rig){
        Vector2 difference = hitted - hitter;
        difference = difference * pushForce;
        rig.AddForce(difference, ForceMode2D.Impulse);

    }




}
