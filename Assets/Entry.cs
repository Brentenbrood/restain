using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry : MonoBehaviour {

    public StatisticsChecker sc;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(sc.stat["Physiological"] >= 10 && sc.stat["Safety"] >= 10 && sc.stat["Belonging"] >= 10 && sc.stat["SelfEsteem"] >= 10 && sc.stat["SelfActualization"] >= 10)
        {
            Destroy(transform);
        }
	}
}
