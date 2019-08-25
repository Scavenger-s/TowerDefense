using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour {
    [Tooltip("子弹速度")]
    public float speed = 1f;
    [Tooltip("子弹攻击力")]
    public  static float damage = 10f;
    
    [Tooltip("子弹攻击目标")]
    public Enemy target;
   
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //必须有目标
            transform.LookAt(target.transform);
        }
        else
        {
            //目标消失，自己销毁
            Destroy(gameObject, 1f);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        Debug.Log("damage "+damage);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null){
            target.HitDamage(damage);

                       
        }
        Destroy(gameObject);
    }
}
