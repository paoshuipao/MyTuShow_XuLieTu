using System.IO;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.UI;





public class DoMonoTest : MonoBehaviour
{


    void Awake()
    {
    }


    void Start()
    {

    }

    void FixedUpdate()
    {
       
    }



    void OnEnable()
    {
    }

    void OnDisable()
    {

    }



    void OnDestroy()
    {

    }




    void Update()
    {
        if (Time.frameCount % 3 == 0)    {  }               // 每3帧才调用一次
        if (Input.GetMouseButtonDown(0)) {  }
        if (Input.GetMouseButtonDown(1)) {  }
        if (Input.GetKeyDown(KeyCode.Q)) {  }
        if (Input.GetKeyDown(KeyCode.W)) {  }
        if (Input.GetKeyDown(KeyCode.E)) {  }
        if (Input.GetKeyDown(KeyCode.R)) {  }
    }

    void OnGUI()
    {

    }




    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Button>().Select();

    }





/*
 
     系度记录下



     
     
     
     
     
     */



}