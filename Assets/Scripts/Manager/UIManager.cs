using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider hpBar;
    // Singleton 처리
    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void SetMaxHP(int hp) {
        hpBar.maxValue = hp;
        hpBar.value = hp;
    }

    public void SetHP(int hp) {
        hpBar.value = hp;
    }
}
