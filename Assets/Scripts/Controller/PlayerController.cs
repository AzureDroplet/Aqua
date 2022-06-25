using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;
    public float moveSpeed = 1.5f;

    public Rigidbody2D rb; 
    public Joystick joystick;

    Vector2 movement;

    public UIManager uiManager;

    void Start()
    {
        currentHP = maxHP;
        uiManager.SetMaxHP(maxHP);
    }

    //Input
    void Update()
    {
        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
        if(Input.GetKeyDown(KeyCode.Space)) {
            Damage(10);
        }
    }

    //Movement
    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Damage(10);
    }

    void Damage(int damage) {
        currentHP -= damage;
        uiManager.SetHP(currentHP);
    }
}
