using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDie : MonoBehaviour {
     
    //死亡的小兵
    public static int enemypass;
    public UImanager ui;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (UImanager.time <= 0) {
            //单例调用
            UImanager.instance.Victory();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy") {
            enemypass++;
           
            Debug.Log("pass");
            ui.DisplayBlood();
            if (enemypass == 5) {
                UImanager.instance.Lose();
                enemypass = 0;
            }
           
        }
    }
}
