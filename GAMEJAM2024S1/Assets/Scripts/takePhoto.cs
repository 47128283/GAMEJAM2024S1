using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering;

public class takePhoto : MonoBehaviour
{
    public KeyCode screenShotButton;
    public KeyCode toggleButton;
    private Boolean toggleCamera;
    public GameObject[] targets;
    public RenderTexture[] plaques;
    // Start is called before the first frame update
    void Start()
    {
        toggleCamera = false;
    }

    // Update is called once per frame
    

private void Update()
{
    
    if (Input.GetKeyDown(toggleButton)) 
    {
        toggleCamera = !toggleCamera;
    }
    
    Cast(targets[0], plaques[0]);
}

private void Capture(RenderTexture boo) 
{
    //ScreenCapture.CaptureScreenshot(Application.dataPath + "/Resources/" + name + ".png");
    //UnityEditor.AssetDatabase.Refresh();
    ScreenCapture.CaptureScreenshotIntoRenderTexture(boo);
    Debug.Log("A screenshot was taken!");
}

private void Cast(GameObject target, RenderTexture plaque) 
{
    Vector3 dir = (target.transform.position - transform.position).normalized;
    float dot = Vector3.Dot(dir, transform.forward);
    if(dot>0.9) 
    {
        if (Input.GetKeyDown(screenShotButton)&&toggleCamera)
    {
       //Capture(target.name);
       //plaque.GetComponent<Renderer>().material.mainTexture = Resources.Load(Application.dataPath + "/Resources/" + target.name + ".png") as Texture;
       Capture(plaque);
    }
    }
}
}
