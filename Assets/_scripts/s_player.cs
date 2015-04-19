using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class s_player : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    public float timeLeft;
    public float count;
    public Text countText;
    public Text totalTime;
    //private GameObject victim;
    private List<GameObject> victimList;
    public Text loseText;
    public Text reloadText;
    public Button reloadButton;
    public Image reloadImage;
    public bool alive;
    private float startTime;
    public float maxSpeed;
    public AudioSource aud;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        updateCountTest();
        Color col = loseText.color;
        col.a = 0f;
        loseText.color = col;
        reloadText.color = col;
        reloadButton.enabled = false;
        reloadImage.enabled = false;
        reloadText.enabled = false;
        victimList = new List<GameObject>();
        //victim = null;
        alive = true;
        startTime = Time.realtimeSinceStartup;
        aud = GetComponent<AudioSource>();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	// Update is called once per frame
	void Update () {
	    
        transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
	}

    void FixedUpdate()
    {
        if (alive)
        {
            float m_horizontal = Input.GetAxis("Horizontal") + Input.acceleration.x;
            float m_vertical = Input.GetAxis("Vertical") + Input.acceleration.y;

            Vector3 movement = new Vector3(m_horizontal, 0, m_vertical);
            if (rb.velocity.magnitude < maxSpeed)
            {
                rb.AddForce(movement * speed);
            }

            timeLeft = timeLeft - Time.deltaTime ;

        stealTime();
        updateCountTest();
        }

        if (timeLeft < 0.02)
        {
            Color col = loseText.color;
            col.a = 1f;
            loseText.color = col;
            reloadText.color = col;
            reloadImage.enabled = true;
            reloadButton.enabled = true;
            reloadText.enabled = true;
            //reloadButton.enabled = true;
            alive = false;

        }

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("person")) {
            //disableParticleVictim();
            //other.gameObject.SetActive(false);
            count = count + 1;
            GameObject victim = other.gameObject;
            ParticleSystem ps = victim.GetComponentInChildren<ParticleSystem>();
            ps.enableEmission = true;
            victimList.Add(victim);
            aud.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        //if (victim != null)
        //{
        if (other.CompareTag("person"))
        { 
            //disableParticleVictim();
            ParticleSystem ps = other.gameObject.GetComponentInChildren<ParticleSystem>();
            ps.enableEmission = false;
        }
//        victim = null;
        victimList.Remove(other.gameObject);
    }

    void updateCountTest()
    {
        countText.text = "Time left: " + timeLeft.ToString("f1");
        totalTime.text = "Total time: " + (Time.realtimeSinceStartup - startTime).ToString("f1");
    }

    void stealTime()
    {
//        if (victim != null){
//            s_person otherPerson = victim.gameObject.GetComponent<s_person>();
//            float otherTime = otherPerson.timeLeft;
//            //Debug.Log("Other time: " + otherTime);
//            float diffTime = otherTime - timeLeft;
//            float adjDiffTime = diffTime * 0.02f;
//            //if (adjDiffTime > 0)
//            //{
//            otherPerson.timeLeft = otherPerson.timeLeft - adjDiffTime;
//            timeLeft = timeLeft + adjDiffTime;
//            //}
//            Transform pinP = victim.transform.FindChild("pinP");
//            Vector3 deltaP = this.transform.position - victim.transform.position;
//            Vector3 dir = victim.transform.InverseTransformDirection(deltaP);
//            float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;

//            pinP.rotation = Quaternion.AngleAxis(-angle + 90, Vector3.up);
//            ParticleSystem ps = pinP.GetComponent<ParticleSystem>();
//            ps.startLifetime = deltaP.magnitude / ps.startSpeed;
//        }

        foreach (GameObject v in victimList)
        {
//        if (victim != null){
            s_person otherPerson = v.gameObject.GetComponent<s_person>();
            float otherTime = otherPerson.timeLeft;
            //Debug.Log("Other time: " + otherTime);
            float diffTime = otherTime - timeLeft;
            float adjDiffTime = diffTime * 0.02f;
            //if (adjDiffTime > 0)
            //{
            otherPerson.timeLeft = otherPerson.timeLeft - adjDiffTime;
            timeLeft = timeLeft + adjDiffTime;
            //}


            //particle system
            Transform pinP = v.transform.FindChild("pinP");
            Vector3 deltaP = this.transform.position - v.transform.position;
            Vector3 dir = v.transform.InverseTransformDirection(deltaP);
            float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg * -1 + 90;

            //pinP.rotation = Quaternion.AngleAxis(-angle + 90, Vector3.up);

            ParticleSystem ps = pinP.GetComponent<ParticleSystem>();
            ps.startLifetime = deltaP.magnitude / ps.startSpeed;
            
            //ps.startColor = Color.Lerp(Color.red, Color.blue, (diffTime + 30)/60);
            if (adjDiffTime < 0)
            {
//                ps.startColor = Color.red;
            pinP.rotation = Quaternion.AngleAxis(angle +180, Vector3.up);
            pinP.position = gameObject.transform.position + new Vector3(0,1,0);
                
            }
            else
            {
 //               ps.startColor = Color.blue;
            pinP.rotation = Quaternion.AngleAxis(angle, Vector3.up);
            pinP.position = v.transform.position + new Vector3(0,1,0);
            }
        }
    }

   // void disableParticleVictim()
   // {
   //     if (victim != null)
   //     {
   //         ParticleSystem ps = victim.GetComponentInChildren<ParticleSystem>();
   //         ps.enableEmission = false;
   //     }
   // }
}
