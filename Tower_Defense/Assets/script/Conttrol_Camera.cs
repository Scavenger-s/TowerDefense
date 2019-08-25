using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conttrol_Camera : MonoBehaviour {
    public Vector3 transvec;
    //最小视野
    public float Min = 30f;
    //最大视野
    public float Max = 80f;
    //滚轮滑动速度
    public float ScrollWheelSpeed = 10f;
    float temp = 0;
    // Use this for initialization
    void Start () {
        transvec = gameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        //滑动鼠标滚轮
        // Mouse ScrollWheel
        //不为0，滑动了滚轮
        /************
            //查找到相机的视角，view
            float cameraView = gameObject.GetComponent<Camera>().fieldOfView;
            //获取滚轮
            mouseScroll = Input.GetAxis("Mouse ScrollWheel");
            Debug.Log(mouseScroll);
            //限制一个值在一个范围之内；
            cameraView = Mathf.Clamp(mouseScroll, Min, Max);
            
            //Debug.Log(cameraView);
            Camera.main.fieldOfView = cameraView;
            
        *********************/
        CanmcrView();
        CamerMove();

    }
    public void CanmcrView() {
        //是不是代表你滑动了滚轮
        //Mouse ScrollWheel  这是滑动鼠标滚轮
        float cameraView = Camera.main.fieldOfView;
        cameraView -= Input.GetAxis("Mouse ScrollWheel") * ScrollWheelSpeed;
        // 这是限制一个值在一个范围之内；
        cameraView = Mathf.Clamp(cameraView, Min, Max);
        Camera.main.fieldOfView = cameraView;

    }
    public void CamerMove() {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            //Debug.Log("mouseX:"+mouseX+"\nmouseY:"+mouseY);
            transform.Translate(new Vector3(-mouseX, 0, -mouseY)*0.3f, Space.World);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10, 20),
                transform.position.y,
                Mathf.Clamp(transform.position.z, -10, 20));
        }
    }
}
