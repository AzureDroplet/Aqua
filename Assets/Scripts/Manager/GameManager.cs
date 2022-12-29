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
    EnemyController _enemyController;
    ItemManager _itemManager;
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
        _enemyController = EnemyController.Instance;
        _itemManager = ItemManager.Instance;
    }

    public void SetGameState(string gameState){

        switch (gameState)
        {
            case "Ready":
                Debug.Log("게임 준비");
                curGameState = GameState.Ready;
                _uiManager.SetReadyUI(); break;

            case "Play":
                Debug.Log("게임 시작");
                curGameState = GameState.Play;
                _uiManager.SetPlayUI();
                CreateEnemyAndItem(); break;

            case "End":
                Debug.Log("게임 오버");
                curGameState = GameState.Play;
                _uiManager.SetEndUI();
                ServerOutput.instance.GetTableList();
                break;
        }
    }
    
    public GameState GetGameState(){
        return curGameState;
    }

    public void CreateEnemyAndItem()
    {
        //enemy랑 item은 싱글톤 안쓰고 하고싶다....
        _enemyController.Start_CreateEnemy();
        _itemManager.Start_CreateItem();
    }

}
