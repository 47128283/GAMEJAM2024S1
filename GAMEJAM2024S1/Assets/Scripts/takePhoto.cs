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
	public RenderTexture source;
	public RenderTexture kill;
    // Start is called before the first frame update
    void Start()
    {
        toggleCamera = false;
		for(int i = 0;i<plaques.Length;i++)
		{
			Graphics.CopyTexture(kill,plaques[i]);
		}
    }

    // Update is called once per frame
    

	private void Update()
	{
    
		if (Input.GetKeyDown(toggleButton)) 
		{
			toggleCamera = !toggleCamera;
		}
		if(targets.Length == plaques.Length)
		{
			for(int i = 0;i<targets.Length;i++)
			{
				Cast(targets[i], plaques[i]);
			}
		}
		
	}

	private void Capture(RenderTexture boo) 
	{
		//ScreenCapture.CaptureScreenshot(Application.dataPath + "/Screenshots/" + System.DateTime.Now.ToString("yy-mm-dd (HH-mm-ss)") + ".png");
		//UnityEditor.AssetDatabase.Refresh();
		//ScreenCapture.CaptureScreenshotIntoRenderTexture(boo);
		Graphics.CopyTexture(source,boo);
		//Debug.Log("A screenshot was taken!");
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
