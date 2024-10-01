using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //SerializeField is used to make variable private but can be accessed in Inspector panel in unity editor
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 14f;

    private float movementX;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    public void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }
    
    //FixedUpdate is called after fixed time rate
    private void FixedUpdate() { 
       PlayerJump(); 
    }

    void PlayerMoveKeyboard(){
        movementX = Input.GetAxisRaw("Horizontal"); //It trigers when user pressess left and right arrow keys
        transform.position += new Vector3(movementX,0f,0f)*moveForce * Time.deltaTime; //for moving character right and left
    }

    void AnimatePlayer(){
        if(movementX>0){
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX=false; //For moving player face towards left
        }
        else if(movementX<0){
            anim.SetBool(WALK_ANIMATION,true);//setBool is used to set value of walk variable which we declared in animator panel
             sr.flipX=true; //For moving player face towards right
        }
        else{
            anim.SetBool(WALK_ANIMATION,false);
        }
    }

    public void PlayerJump(){
        //isGrounded codition is added to prevent from jump while character is in air
        if(Input.GetButtonDown("Jump") && isGrounded){
            isGrounded = false;
            myBody.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
        }
    }

    //It is built-in function to detect whether our character colllides with some object like ground surface
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag(GROUND_TAG)){ //Ground_tag is set on all ground objects in unity isnpector
            isGrounded = true;
        }

        if(collision.gameObject.CompareTag(ENEMY_TAG)){ //Enemy_tag is set on all Enemy objects in unity isnpector
            Destroy(gameObject);
        }
    }
}
