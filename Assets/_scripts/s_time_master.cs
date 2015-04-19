using UnityEngine;
using System.Collections;

public class s_time_master : MonoBehaviour {

    private float time;
    public float timeScale;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        s_master_clock mc = transform.GetComponentInParent<s_master_clock>();
        time = (mc.timeLeft *6 ) / timeScale -90;
        transform.rotation = Quaternion.AngleAxis(time, Vector3.up);
    }
}
