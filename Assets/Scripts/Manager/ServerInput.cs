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
}
