using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using LitJson;

public class ServerOutput : MonoBehaviour
{
    public static ServerOutput instance = null;
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
    
    public void GetTableList()
    {
        var bro = Backend.GameData.GetTableList();

        if (!bro.IsSuccess())
        {
            Debug.LogError(bro.ToString());
            return;
        }

        List<TableItem> tableList = new List<TableItem>();
        JsonData tableListJson = bro.GetReturnValuetoJSON()["tables"];

        for (int i = 0; i < tableListJson.Count; i++)
        {
            TableItem tableItem = new TableItem();

            tableItem.tableName = tableListJson[i]["tableName"].ToString();
            tableItem.tableExplaination = tableListJson[i]["tableExplaination"].ToString();
            tableItem.isChecked = tableListJson[i]["isChecked"].ToString() == "true" ? true : false;
            tableItem.hasSchema = tableListJson[i]["hasSchema"].ToString() == "true" ? true : false;

            tableList.Add(tableItem);
            Debug.Log(tableItem.ToString());
        }
    }

    public void GetRank()
    {
        List<RankItem> rankItemList = new List<RankItem>();
        BackendReturnObject bro = Backend.URank.User.GetRankList("ee436dc0-4575-11ed-ba7e-8b00db4ba65a", 10);
        if (bro.IsSuccess())
        {
            JsonData rankListJson = bro.GetFlattenJSON();

            string extraName = string.Empty;

            for (int i = 0; i < rankListJson["rows"].Count; i++)
            {
                RankItem rankItem = new RankItem();

                rankItem.gamerInDate = rankListJson["rows"][i]["gamerInDate"].ToString();
                rankItem.nickname = rankListJson["rows"][i]["nickname"].ToString();
                rankItem.score = rankListJson["rows"][i]["score"].ToString();
                //rankItem.index = rankListJson["rows"][i]["index"].ToString();
                rankItem.rank = rankListJson["rows"][i]["rank"].ToString();
                //rankItem.totalCount = rankListJson["totalCount"].ToString();

                if (rankListJson["rows"][i].ContainsKey(rankItem.extraName))
                {
                    rankItem.extraData = rankListJson["rows"][i][rankItem.extraName].ToString();
                }

                rankItemList.Add(rankItem);
                Debug.Log(rankItem.ToString());
            }
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.A))
            GetRank();
    }
}

public class TableItem
{
    public string tableName;
    public string tableExplaination;
    public bool isChecked;
    public bool hasSchema;

    public override string ToString()
    {
        return $"tableName : {tableName}\n" +
        $"tableExplaination : {tableExplaination}\n" +
        $"isChecked : {isChecked}\n" +
        $"hasSchema : {hasSchema}\n";
    }
}

public class RankItem
{
    public string gamerInDate;
    public string nickname;
    public string score;
    public string index;
    public string rank;
    public string extraData = string.Empty;
    public string extraName = string.Empty;
    public string totalCount;

    public override string ToString()
    {
        string str = $"유저인데이트:{gamerInDate}\n닉네임:{nickname}\n점수:{score}\n정렬:{index}\n순위:{rank}\n총합:{totalCount}\n";
        if (extraName != string.Empty)
        {
            str += $"{extraName}:{extraData}\n";
        }
        return str;
    }
}