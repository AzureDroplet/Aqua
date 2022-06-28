using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum GameState{
        Ready,
        Start,
        Over
    }

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
    GameState _curGameState = GameState.Ready;
    UIManager _uiManager;

    Start(){
        _uiManager = UIManager.Instance;
    }
    void SetGameState(GameState gameState){
        _curGameState = gameState;

        switch (_curGameState)
        {
            case GameState.Ready:
                Debug.Log("게임 준비");
                _uiManager.SetReadyUI(); break;

            case GameState.Start:
                Debug.Log("게임 시작");
                _uiManager.SetStartUI(); break;

            case GameState.Over:
                Debug.Log("게임 오버");
                _uiManager.SetEndUI(); break;
        }
    }

    GameState GetGameState(){
        return _curGameState;
    }
}
