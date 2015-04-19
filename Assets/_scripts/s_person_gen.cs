using UnityEngine;
using System.Collections;

public class s_person_gen : MonoBehaviour {

    public GameObject person;
    private float lastPersonTime;
    //public Vector3 origin;
    public float pace;
	// Use this for initialization
	void Start () {
        lastPersonTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if (Time.realtimeSinceStartup > lastPersonTime + pace)
        {
            float angle = Random.Range(0, Mathf.PI * 2);
            float x = Mathf.Cos(angle);
            float y = Mathf.Sin(angle);
            Vector3 origin = new Vector3(x, 1, y) * Random.Range(1,8);

            GameObject person_instance = Instantiate(person,
                origin,
                new Quaternion(0, 0, 0, 0)) as GameObject;
            lastPersonTime = Time.realtimeSinceStartup;
        }
    }
}
