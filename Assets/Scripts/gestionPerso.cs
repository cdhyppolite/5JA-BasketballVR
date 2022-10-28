using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class gestionPerso : MonoBehaviour
{
    CharacterController persoController;
    bool isJumping = false;
    Vector3 Velocity;
    float velocityY; // verticale
    float currentSpeed;
    float gravity = -10;
    public float jumpHeight = 1f;

    [SerializeField] InputActionReference btnSaut;

    void Awake()
    {
        btnSaut.action.performed += _ => saut(1);
    }

    void Start()
    {
        persoController = GetComponent<CharacterController>();
        Velocity = Vector3.zero;
    }

    void Update()
    {
        //Saut
        if (Input.GetKeyDown(KeyCode.Space) && persoController.isGrounded) saut(1);
        else isJumping = false;
        
        //physique
        velocityY += gravity * Time.deltaTime;
        currentSpeed = new Vector2(persoController.velocity.x, persoController.velocity.z).magnitude;
        Velocity = currentSpeed * transform.forward + velocityY * Vector3.up;
        persoController.Move(Velocity * Time.deltaTime);
    }
    public void saut(float forceSaut)
    {
        isJumping = true;
        float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight * forceSaut);
        velocityY = jumpVelocity;
    }
    void OnTriggerEnter(Collider infoCol)
    {
        if (infoCol.name == "SautCollider") saut(3);
    }
}