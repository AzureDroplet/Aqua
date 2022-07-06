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
        SetSpeed();
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move(){
        if(moveDir == 0)
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
        else 
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    IEnumerator Destroy(){
        while(true){
            yield return new WaitForSeconds(1);
            if(Mathf.Abs(this.transform.position.x) > 6.0f){
                Destroy(this.gameObject);
                yield break;
            }
        }
    }

    IEnumerator DisableCollider(float time){
        coll.enabled = false;
        yield return new WaitForSeconds(time);
        coll.enabled = true;
    }

    public void SetSpeed(){
        float _speed = Random.Range(0.0f, 5.0f);
        speed = _speed;
    }

    public void SetMoveDir(int dir){
        moveDir = dir;
    }
}
