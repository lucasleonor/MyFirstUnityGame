using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

    public float hero_translaction_speed;
    public float hero_rotation_speed;
    public float hero_jump_speed;
    public float gravity;
    
    
    private static int points;
    private Transform hero;
    private Vector3 move_direction;
    private Animator animator;
    private CharacterController character_controller;
//    static Hero instance;
    // Use this for initialization
    void Start () {
        /*if(instance != null)
       {
            Vector3 new_position = gameObject.transform.position;
            GameObject.Destroy(gameObject);
            instance.transform.position = new_position;
            return;
        }
        GameObject.DontDestroyOnLoad(gameObject);
        instance = this;*/
        hero = GetComponent<Transform>();
        animator = hero.GetComponent<Animator>();
        character_controller = hero.GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        float vertical_ctrl = Input.GetAxis("Vertical");
        float horizontal_ctrl = Input.GetAxis("Horizontal");

        animator.SetFloat("rotation", Mathf.Abs(horizontal_ctrl));
        animator.SetFloat("translation", Mathf.Abs(vertical_ctrl));
        move_direction.y -= gravity * Time.deltaTime;

        character_controller.Move(move_direction * Time.deltaTime);
        if (character_controller.isGrounded)
        {
            move_direction = new Vector3(0, 0, vertical_ctrl);
            move_direction = hero.TransformDirection(move_direction);
            move_direction *= hero_translaction_speed;

            if (Input.GetButton("Jump"))
            {
                move_direction.y = hero_jump_speed;
                animator.Play("jump");
            }
        }

        float rotation_amount = horizontal_ctrl * hero_rotation_speed * Time.deltaTime;
        hero.Rotate(0, rotation_amount, 0);
    }

    public static void AddPoint()
    {
        points++;
    }
    
    public static int Points
    {
        get { return points; }
    }
}
