using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class gestionPerso : MonoBehaviour
{
    //CharacterController
    CharacterController persoController;
    bool isJumping = false;
    Vector3 Velocity;
    float velocityY; // verticale
    float currentSpeed;
    float gravity = -10;
    public float jumpHeight = 1f;

    //Score
    public TextMeshProUGUI zoneScore;
    public static int score;

    //Object victoire
    public GameObject coupeStanley;

    [SerializeField] InputActionReference btnSaut;

    void Awake()
    {
        //Touche pour sauter
        btnSaut.action.performed += _ => saut(1);
    }

    void Start()
    {
        persoController = GetComponent<CharacterController>();
        Velocity = Vector3.zero;

        coupeStanley.SetActive(false);
        score = 0;
    }

    void Update()
    {
        //physique
        velocityY += gravity * Time.deltaTime;
        currentSpeed = new Vector2(persoController.velocity.x, persoController.velocity.z).magnitude;
        Velocity = currentSpeed * transform.forward + velocityY * Vector3.up;
        persoController.Move(Velocity * Time.deltaTime);

        //Afficher le score
        zoneScore.text = score.ToString("00");
        if (score >= 10) coupeStanley.SetActive(true);
    }
    //Saut avec bouton
    public void saut(float forceSaut)
    {
        if (persoController.isGrounded) //Déactiver saut infini
        {
            isJumping = true;
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight * forceSaut);
            velocityY = jumpVelocity;
        }
    }
    //Collisions
    void OnTriggerEnter(Collider infoCol)
    {
        if (infoCol.name == "SautCollider") saut(3);
        if (infoCol.name == "Recommencer") SceneManager.LoadScene(0); // Recharger la scène
    }
}