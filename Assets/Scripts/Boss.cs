using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform target;
    public Transform position;
    public float within_range;
    public float speed;
    public float Health;
    public float damage;
    public float afastaForce;
    private Rigidbody2D rig;
    private bool podeDash;
    private float timeLevel;

    void Start(){
      rig = GetComponent<Rigidbody2D>();
    }


    public void Update(){

    Move();  
    Follow();
    Dead();

    }
    public int intTeste;
    public void Move(){
        /*timeLevel = timeLevel + Time.deltaTime;
        Debug.Log(timeLevel);
        while(timeLevel < 5){
            //Vector3 movement = new Vector3(-contador, 0f, 0f);
            //transform.position += movement * Time.deltaTime *speed;
        }*/
    }
    public void Follow(){
     float dist = Vector3.Distance(target.position, transform.position);
     if(dist <= within_range){
        if(transform.position.x - target.position.x > 0){
            ataque1();
            Debug.Log("ta na esquerda");
        }
      
        else if((transform.position.x - target.position.x < 0)){
            Debug.Log("ta na direita");
        }
      //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);  
      }
    }

    void ataque1(){
        if(podeDash)
            rig.AddForce(new Vector2(-1, 0f), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision){
      if(collision.gameObject.tag == "Player"){
        collision.gameObject.GetComponent<Player>().TakeDamage(damage, transform.position);
        collision.gameObject.GetComponent<Player>().Afasta(afastaForce);
        podeDash = false;
      }
    }

    void OnCollisionExit2D(Collision2D collision){
      if(collision.gameObject.tag == "Player"){
        podeDash = true;
      }
    }
    public void Dead(){
      if(Health <= 0){
        Destroy(gameObject);
      }
    }
}
