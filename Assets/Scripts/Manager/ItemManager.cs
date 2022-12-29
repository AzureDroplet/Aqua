using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Singleton 처리
    public static ItemManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public GameObject[] coins;
    public GameObject[] hearts;
    public GameObject[] trashes;

    public int buildY = -5;

    void Start()
    {
        //StartCoroutine(CreateItem());
    }

    public void Start_CreateItem()
    {
        StartCoroutine(CreateItem());
    }

    IEnumerator CreateItem(){
        while(true){
            yield return new WaitForEndOfFrame();
            if(!GameObject.Find("Player")) continue;
            float PlayerY =  GameObject.Find("Player").transform.position.y;
            if(buildY - PlayerY > 20) continue; //플레이어랑 너무 멀리 떨어져있으면 넘김

            int r = Random.Range(0,100);
            if(r < 20) {
                GameObject i = Instantiate(coins[Random.Range(0,coins.Length)], new Vector2(GetCreatePosX(), buildY), Quaternion.identity) as GameObject;
            }
            else if(r < 30) {
                GameObject i = Instantiate(hearts[Random.Range(0,hearts.Length)], new Vector2(GetCreatePosX(), buildY), Quaternion.identity) as GameObject;
            }
            else if(r < 40) {
                GameObject i = Instantiate(trashes[Random.Range(0,trashes.Length)],new Vector2(GetCreatePosX(), buildY), Quaternion.identity) as GameObject;
            }
            buildY++;
        }
    }

    public int GetItemValue(GameObject item){
        Item _item = item.GetComponent<Item>();
        return _item.value;
    }

    public float GetCreatePosX(){
        float x = Random.Range(-5.0f, 5.0f);
        return x;
    }
}
