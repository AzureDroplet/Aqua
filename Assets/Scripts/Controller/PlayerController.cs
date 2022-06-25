using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    public UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        uiManager.SetMaxHP(maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Damage(10);
        }
    }

    void Damage(int damage) {
        currentHP -= damage;
        uiManager.SetHP(currentHP);
    }
}
