using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    enum ItemClass{
        ScoreItem,
        HPItem
    }

    private ItemClass itemClass;

    [Tooltip("scoreItem : 0, hpItem : 1")] 
    public int itemClass;
    public int value;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
