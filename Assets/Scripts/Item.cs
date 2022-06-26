using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    enum ItemClass{
        ScoreItem,
        HPItem
    }

    public int value;

    public void Destroy(){
        Destroy(this.gameObject);
    }
}
