using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState{
        Ready,
        Play,
        End
    }
    public GameState curGameState = GameState.Ready;
    UIManager _uiManager;

    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null) 
        {
            instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject); 
        }

    }

    void Start(){
        _uiManager = UIManager.Instance; 
    }
    public void SetGameState(GameState gameState){
        curGameState = gameState;

        switch (curGameState)
        {
            case GameState.Ready:
                Debug.Log("게임 준비");
                _uiManager.SetReadyUI(); break;

            case GameState.Play:
                Debug.Log("게임 시작");
                _uiManager.SetPlayUI(); break;

            case GameState.End:
                Debug.Log("게임 오버");
                _uiManager.SetEndUI(); break;
        }
    }

    public GameState GetGameState(){
        return curGameState;
    }
}
