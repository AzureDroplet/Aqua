using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;
    public float moveSpeed = 1.5f;
    public bool isUnBeatTime = false;
    public float unBeatTime = 2; //2초동안 깜빡임

    public Rigidbody2D rb; 
    public Joystick joystick;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    Vector2 movement;

    public UIManager uiManager;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
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
        isUnBeatTime = true;
        boxCollider2D.enabled = false;
        StartCoroutine("UnBeatTime");
    }

    IEnumerator UnBeatTime()
    {
        for(int i = 0; i < unBeatTime * 5; ++i)
        {
            if(i % 2 == 0)
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            else
                spriteRenderer.color = new Color32(255, 255, 255, 180);

            yield return new WaitForSeconds(0.2f);
        }

        //Alpha Effect End
        spriteRenderer.color = new Color32(255, 255, 255, 255);
        boxCollider2D.enabled = true;
        isUnBeatTime = false;

        yield return null;
    }
}
