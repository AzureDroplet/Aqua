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

    GameState _curGameState = GameState.Ready;

    void SetGameState(GameState gameState){
        _curGameState = gameState;

        switch(_curGameState){
            case GameState.Ready : Debug.Log("게임 준비"); break;

            case GameState.Start : Debug.Log("게임 시작");  break;

            case GameState.Over : Debug.Log("게임 오버");  break;
        }
    }

    GameState GetGameState(){
        return _curGameState;
    }
}
