using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//场景管理
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour {
    //单例，方便其他类的调用
    public static UImanager instance;
    [Tooltip("开始界面")]
    public GameObject StartPanel;
    [Tooltip("选择界面")]
    public GameObject LevelPanel;
    public Text text;
    [Tooltip("血量百分比")]
    public Text bloodtext;
    public Slider slider;
    //失败界面
    public GameObject LosePanel;
    //成功界面
    public GameObject VictoryPanel;
    public static int time = 60;
    //血量
    public int hp = 100;
    //金钱显示框
    public Text tmoney;
    //金钱
    public float fmoney = 1000;
    // Use this for initialization
    void Start() {
        slider.maxValue = 5f;
        slider.value = 5f;
        StartCoroutine("Times");
        instance = this;
        text.text = "Time :" + time + "s";
        bloodtext.text = "100%";
        tmoney.text = "金钱:" + fmoney+"$";
    }

    // Update is called once per frame
    void Update() {

        tmoney.text = "金钱:" + fmoney + "$";
    }
    IEnumerator Times()
    {

        while (true)
        {
            yield return new WaitForSeconds(1f);
            time--;
            text.text = "Time :" + time + "s";
        }
    }

    /// <summary>
    ///开始游戏方法
    /// </summary>
    public void StartOnClick() {
        StartPanel.SetActive(false);
        LevelPanel.SetActive(true);
    }
    /// <summary>
    ///关卡选择方法绑定
    /// </summary>
    public void LevelOnClick()
    {
        StartPanel.SetActive(true);
        LevelPanel.SetActive(false);
    }
    ///<summary>
    ///场景跳转
    ///</summary>
    public void SceneOnClick(int a) {
        SceneManager.LoadScene(a);
    }
    ///<summary>
    ///游戏失败
    ///</summary>
    public void Lose() {
        Time.timeScale = 0;
        LosePanel.SetActive(true);
    }
    ///<summary>
    ///显示血条
    ///</summary> 
    public void DisplayBlood() {
        slider.value = 5 - EnemyDie.enemypass;
        hp -= 20;
        bloodtext.text = hp+ "%";
       
    }
    ///<summary>
    ///游戏胜利
    ///</summary>
    public void Victory() {
        Time.timeScale = 0;
        VictoryPanel.SetActive(true);
        
    }
    /// <summary>
    ///重新开始游戏方法
    /// </summary>
    public void ReStartOnClick(int a)
    {
        SceneManager.LoadScene(a);
        Time.timeScale = 1;
        LosePanel.SetActive(false);
      
        slider.value = 5f;
        time = 60;
        hp = 100;
    }
    /// <summary>
    ///return按钮绑定
    /// </summary>
    public void ReturnOnClick(int a) {
       
        SceneManager.LoadScene(a);
        VictoryPanel.SetActive(false);
        Time.timeScale = 1;
        slider.value = 5f;
        time = 60;
        hp = 100;
    }
    public void NextOnClick(int a) {
        SceneManager.LoadScene(a);
    }
    public void ExitOnClick() {
        Application.Quit();
    }
}
