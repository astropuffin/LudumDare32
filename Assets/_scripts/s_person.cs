using UnityEngine;
using System.Collections;

public class s_person : MonoBehaviour {

    public float timeLeft;
    public Vector3 goal;
    public float speed;
    Rigidbody rb;
    public float startTime;
    public float endTime;
    private Renderer rend;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        timeLeft = Random.Range(startTime, endTime);
        speed = 1;
        setGoal();
        rend = GetComponent<Renderer>();
        rend.material.color = generateRandomColor();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        timeLeft = timeLeft - Time.deltaTime;

        if (timeLeft < 0)
        {
            Destroy(gameObject);
        }
        transform.rotation = Quaternion.AngleAxis(0, Vector3.up);

        move();

    }

    void move()
    {
        float _distance = (goal - transform.position).magnitude;
        //if we've already gotten to our goal, then don't try to move closer or rotate
        if (_distance > .5)
        {
//            transform.position = Vector3.MoveTowards(transform.position, goal, speed);
            //don't care about y value
            Vector3 noY = new Vector3(transform.position.x,0,transform.position.z);
            Vector3 push = (goal - noY).normalized * speed;
            rb.AddForce(push);
        }
        else
        {
            setGoal();
        }
    }

  public void setGoal(){

//    goal = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));

    float angle = Random.Range(0, Mathf.PI * 2);
      float x = Mathf.Cos(angle);
      float y = Mathf.Sin(angle);
      goal = new Vector3(x, 0, y) * 9;
  }

  private Color generateRandomColor()
  {
      Color mix = new Color(1, 1, 1);
      //Color mix = new Color(255, 255, 255);
      Random random = new Random();
      float red = Random.value;
      float green = Random.value;
      float blue = Random.value;

      // mix the color
      red = (red + mix.r) / 2;
      green = (green + mix.g) / 2;
      blue = (blue + mix.b) / 2;

      Color color = new Color(red, green, blue);
      return color;
//      return mix;
  }
        void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("hero")) {
            ParticleSystem ps = GetComponentInChildren<ParticleSystem>();
            ps.enableEmission = false;
        }
    }

}
