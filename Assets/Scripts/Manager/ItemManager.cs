using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public GameObject[] coins;
    public GameObject[] hearts;
    public GameObject[] trashes;

    public void Create(){

    }

    public void Destroy(){

    }

    public int GetItemValue(GameObject item){
        item _item = item.GetComponent<item>();
        const int itemValue = _item.value;
        return itemValue;
    }

    public int GetItemClass(GameObject item){
        item _item = item.GetComponent<item>();
        const int itemClass = _item.itemClass;
        return itemClass;       
    }
}
