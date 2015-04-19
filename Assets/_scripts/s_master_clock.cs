using UnityEngine;
using System.Collections;

public class s_master_clock : MonoBehaviour {

    public GameObject player;
    public float timeLeft;
    private Color colorEnd = Color.red;
    private Color colorStart = Color.blue;
    public float maxTime;
    Renderer rend;
    AudioSource aud;
    bool alive;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LateUpdate()
    {
        s_player sp = player.GetComponent<s_player>();
        timeLeft = sp.timeLeft;
        alive = sp.alive;
        updateMood();
    }

    void updateMood()
    {

        float fract;
        if (timeLeft < maxTime)
        {
            fract = timeLeft / maxTime;
        }
        else
        {
            fract = 1;
        }
        rend.material.color = Color.Lerp(colorStart, colorEnd, 1- fract);
        if (alive)
        {
            aud.volume = 0.7f * (1 - fract) * (1 - fract) * (1 - fract);
        }
        else
        {
            aud.volume = 0;
        }
    }

}
