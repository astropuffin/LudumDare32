using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class s_reload : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
