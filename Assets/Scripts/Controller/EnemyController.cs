using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public static EnemyController instance = null;

    private void Awake()
    {
        if (instance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            instance = this; //내자신을 instance로 넣어줍니다.
            DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
        }
        else
        {
            if (instance != this) //instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미
                Destroy(this.gameObject); //둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제
        }

    }

    public GameObject[] Enemys;

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
                GameObject e = Instantiate(Enemys[Random.Range(0,Enemys.Length)], new Vector2(-10, GetCreatePosY()), Quaternion.identity) as GameObject;
                e.GetComponent<Enemy>().SetMoveDir(1);
            }
            else{
                GameObject e = Instantiate(Enemys[Random.Range(0,Enemys.Length)], new Vector2(10, GetCreatePosY()), Quaternion.identity) as GameObject;
                e.GetComponent<Enemy>().SetMoveDir(0);
            }
        }
    }

    public float GetCreatePosY(){
        //float PlayerY = PlayerController.transform.position.y;
        float PlayerY = 0;
        float r = Random.Range(-5.0f, 5.0f);
        return PlayerY + r;
    }
}
