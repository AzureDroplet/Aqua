using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider hpBar;
    public Gradient gradient;
    public Image fill;
    // Singleton 처리
    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void SetMaxHP(int hp) {
        hpBar.maxValue = hp;
        hpBar.value = hp;
        // slider 1값일 때의 gradient 색으로 설정
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHP(int hp) {
        hpBar.value = hp;
        fill.color = gradient.Evaluate(hpBar.normalizedValue);
    }
}
