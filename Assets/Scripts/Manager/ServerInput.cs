using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;

public class ServerInput : MonoBehaviour
{
    public static ServerInput instance = null;
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
    public void InsertTest()
    {
        string _name = "aqua";
        int _score = 100;
        
        Param param = new Param();
        param.Add("name", _name);
        param.Add("score", _score);

        Backend.GameData.Insert("Score", param);

    }
    
    public void AddRank(string name, int score)
    {
        Debug.Log("addrank 실행성공");
        string _name = name;
        int _score = score;
        
        Param param = new Param();
        param.Add("name", _name);
        param.Add("nickname", _name);
        param.Add("score", _score);
        Backend.BMember.CreateNickname(_name);

        var bro = Backend.GameData.Insert("Score", param);
        string inDate = bro.GetInDate();
        Backend.URank.User.UpdateUserScore("3fb1a600-876f-11ed-88f1-73a88c58b3e8", "Score", inDate, param);

    }

}
