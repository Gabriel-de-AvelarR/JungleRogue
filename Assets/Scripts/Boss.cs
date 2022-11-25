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
    
    public float direcao;
    public float mergulhoForce;

    void Start(){
      rig = GetComponent<Rigidbody2D>();
    }


    public void Update(){

    Move();  
    //Follow();
    Dead();

    }
    public void Move(){
        Vector3 movement = new Vector3(direcao, 0, 0);
        transform.position += movement * Time.deltaTime *speed;
        randomizaGolpe();

    }
    public int aleatorio;
    public void randomizaGolpe(){
        aleatorio = Random.Range(0,1000);
        if(aleatorio < 1){
        mergulha();
      }
    }
    public void mergulha(){
      Debug.Log("Entrou");

      aleatorio = Random.Range(0,1000);
      if(aleatorio < 1){

      }
    }
    public void Follow(){
     float dist = Vector3.Distance(target.position, transform.position);
     if(dist <= within_range){
        if(transform.position.x - target.position.x > 0){
            ataque1();
        }
      
        else if((transform.position.x - target.position.x < 0)){
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

      if(collision.gameObject.layer == 8){
        direcao = direcao * (-1);
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
