using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //set the values in the inspector
    public Transform target;
    public Transform position;


    public float within_range;
    public float speed;
    public float Health;
    public float damage;
    public float afastaForce = 15;

    private Rigidbody2D rig;
    public playerMelee CombatController;

    void Start(){
      rig = GetComponent<Rigidbody2D>();
    }

    public void Update(){

      Follow();
      Dead();

    }

    void OnCollisionEnter2D(Collision2D collision){
      if(collision.gameObject.tag == "Player"){
        collision.gameObject.GetComponent<Player>().TakeDamage(damage, transform.position);
        collision.gameObject.GetComponent<Player>().Afasta(afastaForce);
      }
    }

    public void Follow(){
     float dist = Vector3.Distance(target.position, transform.position);
     if(dist <= within_range){
      transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);  
      }
    }


    public void TakeDamage(float attackDamage){
      Health -= attackDamage;
      CombatController = GameObject.FindGameObjectWithTag("GameController").GetComponent<playerMelee>();

      CombatController.pushBack(transform.position, target.position, rig);

      /*Vector2 difference = transform.position - target.position;
      difference = difference * pushBack;
      rig.AddForce(difference, ForceMode2D.Impulse);*/

    }

    public void Dead(){
      if(Health <= 0){
        Destroy(gameObject);
      }
    }
     

  }
