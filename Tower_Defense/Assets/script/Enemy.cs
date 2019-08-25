using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    //移动的速度
    public float movespeed=5f;
    //路径点
    public Transform[] Paths;
    //目标点
    private Transform target;
    //索引值
    public int index = 0;
    private Animator animators;
    //开始活着
    public bool isDead = false;
    [Tooltip("怪物死亡音效")]
    private AudioSource Enemyaudio;
    GameManager gamemanager;
    //让小兵朝向目标点移动，到达目标点附件时切换到下一个目标点，改变方向
    // Use this for initialization
    void Start () {
       
        //设置第一个目标点
        
        Enemyaudio = gameObject.GetComponent<AudioSource>();
        target = Paths[index];
        transform.rotation = Quaternion.LookRotation(target.position - transform.position);
        animators = GetComponent<Animator>();
    }
    
	// Update is called once per frame
	void Update () {
        //活着时向前移动，死了向下
        if (isDead == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movespeed);

            if (index < Paths.Length-1)
            {
                //判断距离是否到达目标点附件
                if (Vector3.Distance(transform.position, target.position) <= 0.5f)
                {
                    //切换目标点
                    index++;
                    target = Paths[index];
                    transform.rotation = Quaternion.LookRotation(target.position - transform.position);
                    
                   
                }
            }
            else {
                    Debug.Log("yes");
                    Destroy(gameObject);
            }
                
        }
        else
            transform.Translate(-Vector3.up * Time.deltaTime*1.5f);

        

    }
    //定义一个血量,定义一个方法用来见血，血量<0,死了
    public float HP = 100f;
    public void HitDamage(float damage)
    {
        //减血
        HP -= damage;
        if (HP <= 0 && isDead == false) {
            //gamemanager.count++;获取敌人死亡数量
            //播放死亡音乐
            Enemyaudio.Play();
            //进入死亡，播放死亡动画
            isDead = true;
            animators.SetTrigger("Death");
            Destroy(gameObject, 2f);
            Debug.Log("dead");
            if (gameObject.name == "skeleton_archer(Clone)")
            {
                UImanager.instance.fmoney += 10;
                Debug.Log(gameObject.name);
            }
            else if (gameObject.name == "skeleton_base(Clone)")
            {
                UImanager.instance.fmoney += 50;
            }
            else if (gameObject.name == "skeleton_king(Clone)")
            {
                UImanager.instance.fmoney += 250;
            }
            else if (gameObject.name == "skeleton_mage(Clone)")
            {
                UImanager.instance.fmoney += 20;
            }
            else if (gameObject.name == "skeleton_warrior(Clone)")
            {
                UImanager.instance.fmoney += 25;
            }
        }
       

    }
}
