using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour
{
    public static PlayerMgr inst;

    private void Awake()
    {
        inst = this;
    }

    /*---------- Properties ----------*/
    [Header("Physics-Related Properties")]
    public GameObject player;
    public Transform playerBody;
    public CharacterController characterController;
    public CapsuleCollider playerCollider;

    [Header("Movement")]
    public float walkSpeed = 12f;
    public float runSpeed = 20f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public float distToGround = 1f; // Distance from center of player capsule to bottom of capsule, where ground makes contact

    public Vector3 velocity;

    [Header("Cameras")]
    public Camera playerCamera;
    public float normalFOV;

    /*---------- Methods ----------*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*----- Y-axis Movement -----*/
        // Check if you land on the ground
        if (Physics.Raycast(playerBody.position, Vector3.down, distToGround + 0.1f) && velocity.y < 0)
        {
            velocity.y = 0;
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

    }
}
