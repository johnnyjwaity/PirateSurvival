using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeSceneOverTime : MonoBehaviour {
    public float time;
    public Image FadePanel;
    public float rate;
    private float rateCounter;
    private bool Done;
    private bool sceneChange;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!Done)
        {
            Color c = FadePanel.color;
            c.a = Mathf.Lerp(FadePanel.color.a, 1f, Time.deltaTime * rate);
            FadePanel.color = c;
            Debug.Log(FadePanel.color.a);
            if(FadePanel.color.a > 0.99)
            {
                Done = true;
            }
        }
        else
        {
            Color c = FadePanel.color;
            c.a = Mathf.Lerp(FadePanel.color.a, 0f, Time.deltaTime * rate);
            FadePanel.color = c;
            if(FadePanel.color.a < 0.01)
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
        

    
}
