using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public GameObject[] Enemys;
    private float PlayerPosY;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    IEnumerator CreateEnemy(){
        while(true){
            yield return new WaitForSeconds(1.0f);
            int r = Random.Range(0,2);
            if(r == 0){
                GameObject e = Instantiate(Enemys[Random.Range(0,Enemys.Length)], new Vector2(-5, GetCreatePosY()), Quaternion.identity) as GameObject;
                e.GetComponent<Enemy>().SetMoveDir(1);
            }
            else{
                GameObject e = Instantiate(Enemys[Random.Range(0,Enemys.Length)], new Vector2(5, GetCreatePosY()), Quaternion.identity) as GameObject;
                e.GetComponent<Enemy>().SetMoveDir(0);
            }
        }
    }

    public float GetCreatePosY()
    {
        if (!GameObject.Find("Player")) return Random.Range(-5.0f, 10.0f);
        float r = Random.Range(-5.0f, 10.0f);
        float PlayerY; PlayerY = GameObject.Find("Player").transform.position.y;
        return PlayerY + r;
    }
}
