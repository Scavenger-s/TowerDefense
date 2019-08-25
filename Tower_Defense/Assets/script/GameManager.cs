using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    //生成的小兵
    public GameObject[] enemy;
    //路径点
    public Transform[] Paths;
    //间隔时间
    public float interval = 2f;
    //数量
    public int count;
    public Transform location;
 
    
	// Use this for initialization
	void Start () {
        InvokeRepeating("ProduceEnemy", interval,2f);

	}
   

	// Update is called once per frame
	void Update () {
      
        
	}
    public void ProduceEnemy() {
        GameObject go = Instantiate(enemy[Random.Range(0, enemy.Length)], location.position, Quaternion.identity) as GameObject;
        go.GetComponent<Enemy>().Paths = Paths;
    }
}
