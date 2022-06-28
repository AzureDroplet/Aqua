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

    void Start(){
        _uiManager = UIManager.Instance; 
    }
    void SetGameState(GameState gameState){
        _curGameState = gameState;

        switch (_curGameState)
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

    GameState GetGameState(){
        return _curGameState;
    }
}
