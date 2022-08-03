using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using LitJson;

public class ServerOutput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Backend.GameData.GetTableList();
    }

    // Update is called once per frame
    void Update()
    {
        
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