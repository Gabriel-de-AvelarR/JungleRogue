using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool isJumping; 
    bool facingRight = true;
    bool wallSliding;
    float sideofWall;
    public float wallSlidingSpeed;
    public float wallJump;
    public float maxHealth;
    public float Health;
    public float molaForce;

    bool isOnGate = false;
    int nextLevel = 0;
    bool hasKey;

    string[] sceneNameList = new string[] {"Level1", "Level2", "Level3"};
    
    public UIManager UI;

    private Rigidbody2D rig;

    public Animator animator;

    public playerMelee CombatController;


    void Start()
    {
        maxHealth = Health;
        rig = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Move();
        Jump();

        CombatController = GameObject.FindGameObjectWithTag("GameController").GetComponent<playerMelee>();

        ActivatePunch(CombatController.isPunch);
        ActivateKick(CombatController.isKick);
        ActivateBlock(CombatController.isBlock);
        ActivateUlt(CombatController.isUlt);

        if(isOnGate && Input.GetKeyDown(KeyCode.UpArrow)){
            SceneManager.LoadScene("Loja");
        }

        GameOver();
    }

    void  Move(){
        float input = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(input, 0f, 0f);
        transform.position += movement * Time.deltaTime *Speed;
        animator.SetFloat("Speed", Mathf.Abs(input));

        if(input < 0 && facingRight == true){
            Flip();
        }
        else if(input > 0 && facingRight == false){
            Flip();
        }

       if(wallSliding){
            //aplicacao do deslize da parede
            rig.velocity = new Vector2(rig.velocity.x, Mathf.Clamp(rig.velocity.y, -wallSlidingSpeed, float.MaxValue));
             
            if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)){
                rig.AddForce(new Vector2(wallJump, wallJump*4), ForceMode2D.Impulse);
            }
        }
    }

    void Flip(){
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        if(facingRight){
            facingRight = false;
        }
        else{
            facingRight = true;
        }

    }

    void Jump(){
        if(Input.GetButtonDown("Jump") && !isJumping){
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }

    public void TakeDamage(float attackDamage, Vector2 positionEnemy){
        //verify first if the player is blocking
        CombatController = GameObject.FindGameObjectWithTag("GameController").GetComponent<playerMelee>();
        if(!CombatController.isBlock){
            
            Health -= attackDamage;

            CombatController.pushBack(transform.position, positionEnemy, rig);
            UI.reduceHearts(Health, maxHealth);

            //push back
            /*Vector2 difference = transform.position - Enemy.position;
            difference = difference * pushBack;
            rig.AddForce(difference, ForceMode2D.Impulse);
            */
        }

    }

    public void ActivatePunch(bool condition){
        if(condition){

            animator.Play("PlayerPunch");
            CombatController.reset();
        }
    }
    public void ActivateKick(bool condition){
        if(condition){
            animator.Play("PlayerKick");
            CombatController.reset();
        }
    }
    public void ActivateBlock(bool condition){
        if(condition){
            animator.Play("PlayerBlock");
            CombatController.reset();
        }
    }
    public void ActivateUlt(bool condition){
        if(condition){
            //animator.Play("PlayerUlt");
            CombatController.reset();
        }
    }

    void GameOver(){
        if(Health <= 0){
            SceneManager.LoadScene("DeathScreen");
        }
    }

    public void Afasta(float afastaForce){
            rig.AddForce(new Vector2(0f, afastaForce), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 8){
            isJumping = false;
        }

        if(collision.gameObject.tag == "Wall" && isJumping == true){
            sideofWall = Input.GetAxis("Horizontal");
            wallSliding = true;
        }

        if(collision.gameObject.tag == "Gate"){
            isOnGate = true;
        }

        if(collision.gameObject.tag == "CheckPoint"){
            nextLevel++;
            Debug.Log(nextLevel);
            SceneManager.LoadScene(sceneNameList[nextLevel]);
        }

        if(collision.gameObject.tag == "Chest" && hasKey){
            //get item
        }
        if(collision.gameObject.tag == "mola"){
            isJumping = false;
            JumpForce = JumpForce * molaForce;
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if((collision.gameObject.layer == 8) || (collision.gameObject.tag == "mola")){
            isJumping = true;
        }

        if(collision.gameObject.tag == "Wall"){
            wallSliding = false;
        }

        if(collision.gameObject.tag == "Gate"){
            isOnGate = false;
        }

        if(collision.gameObject.tag == "mola"){
            JumpForce = JumpForce / molaForce;
        }
    }
    
}

