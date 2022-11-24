using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float damage;
    private Rigidbody2D rig;

    void Start(){
      rig = GetComponent<Rigidbody2D>();
    }


    public void Update(){
    }

    void OnCollisionEnter2D(Collision2D collision){
      if(collision.gameObject.tag == "Player"){
        collision.gameObject.GetComponent<Player>().TakeDamage(damage, transform.position);
      }
    }
  }
