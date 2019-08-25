using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour {
    //箭塔，升级，出售，判断是否是建塔是出售(显示是什么样的ui)
    // Use this for initialization
    //塔是否有
    public  bool isHaveTower = false;
    //建塔的ui
    GameObject buildTower;
    //升级ui
    GameObject upgradeTower;
    GameObject Tower;
    public Tow Currenttowe;
    [Tooltip("塔的等级")]
    public int level = 1;
    
    void Start() {
        Tower = GameObject.FindGameObjectWithTag("buildTower").transform.GetChild(0).gameObject;
        buildTower = Tower.transform.GetChild(0).gameObject;
        upgradeTower = Tower.transform.GetChild(1).gameObject;
        //ShowUi();
        
    }

    // Update is called once per frame
    void Update () {
       
	}
    /**显示UI*/
   public void ShowUi() {
        if (!isHaveTower) {
            buildTower.SetActive(true);
            upgradeTower.SetActive(false);
        }
        else {
            upgradeTower.SetActive(true);
            buildTower.SetActive(false);
        }
            
    }
    /**建塔的方法,tower,塔*/
    public void ToBuildTower(GameObject tower) {
        if (UImanager.instance.fmoney >= 100) { 

         GameObject go = Instantiate(tower, transform.position+Vector3.up*3, Quaternion.identity) as GameObject;
        //等级为一级
        //把你的钱花掉
        isHaveTower = true;
        Currenttowe = go.GetComponent<Tow>();
        //level++;
        UImanager.instance.fmoney -= 100;
        level = 1;
        }
    }
    public void ToUpTower() {

        //升级之后
         GameObject temp = Currenttowe.UpTowe;
        
            if (temp != null)
            {
               if (UImanager.instance.fmoney >= 100)
               {
                //Currenttowe.towermoney + level * 100 ,目前升级所需要的钱
                if (UImanager.instance.fmoney >= Currenttowe.towermoney + level * 100)
                {
                    
                    Destroy(Currenttowe.gameObject);

                    GameObject go1 = Instantiate(temp, transform.position + Vector3.up * 3,
                    Quaternion.identity) as GameObject;

                    Currenttowe = go1.GetComponent<Tow>();

                    isHaveTower = true;
                }
                level++;
                Debug.Log("level:"+level);
                UImanager.instance.fmoney -= level * 100;

               }
               
            }
       
    }
    /**出售塔*/
    public void ToSellTower()
    {
        
        Destroy(Currenttowe.gameObject);
        isHaveTower = false;
        UImanager.instance.fmoney += Currenttowe.sellmoney; 
        level = 0;
    }
}
