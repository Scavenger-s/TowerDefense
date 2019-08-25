using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tow : MonoBehaviour {
    [Tooltip("攻击范围")]
    public float AttackRange = 5f;
    [Tooltip("子弹发射间隔时间")]
    public float interval = 2f;
    [Tooltip("目标小兵")]
    public Enemy target;
    [Tooltip("子弹预设物")]
    public Bullet bullet;
    [Tooltip("子弹的开火位置")]
    public Transform firePos;
    [Tooltip("会旋转的炮塔")]
    public Transform turret;
    [Tooltip("升级塔")]
    public GameObject UpTowe;
    public int towermoney =0;
    public int sellmoney = 0;
    //伤害
    public int damage;
    // Use this for initialization
    void Start () {
        //将圆的半径表现为攻击范围
        gameObject.GetComponent<SphereCollider>().radius = AttackRange;
        StartCoroutine("Fire");
        Bullet.damage = damage;
	}
    IEnumerator Fire()
    {
        //隔几秒发射子弹
        while (true)
        {
            yield return new WaitForSeconds(interval);
            //一直循环
            if (target != null)
            {
                //有了攻击目标
                Bullet newBullet = Instantiate(bullet);
                //放在开火位置
                newBullet.transform.position = firePos.position;
                newBullet.target = target;
                
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("yes");
        if (target == null) {
            Enemy oneEnemy = other.GetComponent<Enemy>();
            if (oneEnemy != null) {
                //敌人存在
                target = oneEnemy;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //当碰撞结束的时候执行一次
        //当目标离开攻击范围时，目标清空
        Debug.Log("out");
        Enemy oneEnemy = other.GetComponent<Enemy>();
        if (oneEnemy == target)
        {
            //如果要离开的小兵是攻击目标
            target = null;
        }
    }
    // Update is called once per frame
    void Update () {
        if (target != null) {
            if (target.isDead == false)
            {
                turret.rotation = Quaternion.LookRotation(target.transform.position - turret.position);
            }
            else
                //如果目标被打死就切换对象
                target = null; 
        }
        
	}
}
