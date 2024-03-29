using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider hpBar;
    public Gradient hpGradient;
    public Image fill;
    public Text textScore;

    public Gradient bgGradient;

    public Button button_Start;
    public Button button_Restart;

    public Text textNickname;
    public GameObject[] GameUI;

    // Singleton 처리
    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void SetScore(int score) {
        textScore.text = "Score : " + score.ToString();
    }

    public void SetMaxHP(int hp) {
        hpBar.maxValue = hp;
        hpBar.value = hp;
        // slider 1값일 때의 gradient 색으로 설정
        fill.color = hpGradient.Evaluate(1f);
    }

    public void SetHP(int hp) {
        hpBar.value = hp;
        fill.color = hpGradient.Evaluate(hpBar.normalizedValue);
    }
    public void SetReadyUI() {
        GameUI[(int)GameManager.GameState.Ready].SetActive(true);
        GameUI[(int)GameManager.GameState.Play].SetActive(false);
        GameUI[(int)GameManager.GameState.End].SetActive(false);
    }
    public void SetPlayUI() {
        GameUI[(int)GameManager.GameState.Ready].SetActive(false);
        GameUI[(int)GameManager.GameState.Play].SetActive(true);
        GameUI[(int)GameManager.GameState.End].SetActive(false);
    }
    public void SetEndUI() {
        GameUI[(int)GameManager.GameState.Ready].SetActive(false);
        GameUI[(int)GameManager.GameState.Play].SetActive(false);
        GameUI[(int)GameManager.GameState.End].SetActive(true);
    }
}
