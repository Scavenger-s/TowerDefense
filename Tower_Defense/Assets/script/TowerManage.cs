using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerManage : MonoBehaviour {
    Ray ray;
    RaycastHit hit;
    GameObject obj;
    //从射线检测到的基座位置
    Vector3 pos;
    TowerBase towerbase;
    //建塔的ui
    public GameObject buildTower;
    //升级ui
    public GameObject upgradeTower;
    //定义一个塔的数组
    public GameObject[] towers;
    [Tooltip("音乐")]
    private AudioSource audiosource;
    // Use this for initialization
    void Start () {
        audiosource = gameObject.GetComponent<AudioSource>();
	}
    //声明一个层
    public LayerMask layermask;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //声明一条射线
            Ray ray;
            //接收到碰撞物体的信息
            RaycastHit hit;
            //从屏幕构造一条射线
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f, layermask))
            {
                //判断鼠标是否点击到了ui
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    Invoke("HiddenUi",0.5f);
                    
                }
                else
                {
                    
                    towerbase = hit.collider.GetComponent<TowerBase>();
                    towerbase.ShowUi();
                    //存一下坐标
                   //射线碰到的位置
                    pos = hit.point;

                   //让ui坐标转换成pos
                   buildTower.transform.position = Camera.main.WorldToScreenPoint(pos);

                   upgradeTower.transform.position = Camera.main.WorldToScreenPoint(pos);

                 }

                
                
            }
            else
            {
                Invoke("HiddenUi", 0.2f);
            }
        }
        
    }
    
    //点按钮生成，按钮绑定
    public void OnClickBuiltTower(int a) {
    //调用生成塔的方法
        towerbase.ToBuildTower(towers[a]);
    //生成音乐
        audiosource.Play();
    }
    public void HiddenUi() {
        buildTower.SetActive(false);
        upgradeTower.SetActive(false);
    }
    //升级塔
    public void OnClickUpTower() {
        towerbase.ToUpTower();
       
    }
    /**出售塔*/
    public void OnClickSellTower()
    {
        towerbase.ToSellTower();
    }
}
