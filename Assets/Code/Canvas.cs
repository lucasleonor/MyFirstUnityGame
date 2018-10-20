using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour {
    
    public Text points;

    static Canvas instance;
    // Use this for initialization
    void Start () {
       if(instance != null)
       {
           GameObject.Destroy(gameObject);
           return;
       }
       GameObject.DontDestroyOnLoad(gameObject);
       instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        points.text = "Points: "+ Hero.Points;
	}
}
