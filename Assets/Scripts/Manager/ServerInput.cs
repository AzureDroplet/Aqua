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
        param.Add("nickname", _name);
        param.Add("score", _score);

        var bro = Backend.GameData.Insert("Score", param);
        string inDate = bro.GetInDate();
        Backend.URank.User.UpdateUserScore("ee436dc0-4575-11ed-ba7e-8b00db4ba65a", "Score", inDate, param);

    }

}
