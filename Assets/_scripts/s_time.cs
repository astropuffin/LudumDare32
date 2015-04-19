using UnityEngine;
using System.Collections;

public class s_time : MonoBehaviour {

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
        s_player player = transform.GetComponentInParent<s_player>();
        time = (player.timeLeft *6 ) / timeScale -90;
        transform.rotation = Quaternion.AngleAxis(time, Vector3.up);
    }
}
