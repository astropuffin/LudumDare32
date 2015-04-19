using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class s_fade_image : MonoBehaviour {

        private float gamestart;
    public float fadeIn;
    public float fullAlpha;
    public float fadeOut;
    public float gone;
    private Image sprite;
    public Color col;

	// Use this for initialization
	void Start () {
	        gamestart = Time.realtimeSinceStartup;
        sprite = GetComponent<Image>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
        void FixedUpdate()
    {
        float deltaTime = Time.realtimeSinceStartup - gamestart;
        if (deltaTime > gone)
        {
            col.a = 0f;
        }
        else if (deltaTime > fadeOut)
        {
            col.a = (gone - deltaTime)/(gone - fadeOut);
        }
        else if (deltaTime > fullAlpha)
        {
            col.a = 1f;
        }
        else if (deltaTime > fadeIn)
        {
            col.a = (deltaTime - fadeIn)/(fullAlpha - fadeIn);
        }
        else
        {
            col.a = 0f;
        }
        sprite.color = col;
    }

}
