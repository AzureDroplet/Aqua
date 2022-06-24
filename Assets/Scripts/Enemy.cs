using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int moveDir;
    public int damage;
    public string name;

    public Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        coll = this.GetComponent<Collider2D>();
        Debug.Log(coll.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //오브젝트 풀링 사용
    public void Create(){

    }

    public void Destroy(){

    }

    public void SetCollider(bool isVisible){

    }

    public void SetDamage(){

    }
}
