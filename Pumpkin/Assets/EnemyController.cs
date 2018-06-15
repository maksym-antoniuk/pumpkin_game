using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class EnemyController : MonoBehaviour {

    Animator anim;
    bool end = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (end)
        {
            if (!AnimatorIsPlaying("end"))
            {
                Debug.Log("kaban entesasasasdasdsar", null);
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)

    {
        //GetComponent<Animation>().wrapMode = WrapMode.Once;
        //GameObject.Find("PumpkinIdle").animation["DeadPumpkin"].wrapMode = WrapMode.Once;
        if (col.CompareTag("Kaban") || col.CompareTag("Bird") || col.CompareTag("Stone") || col.CompareTag("Boss"))
        {
            anim.Play("DeadPumpkin");
            end = true;
            //while (!anim.GetCurrentAnimatorStateInfo(0).IsName("DeadPumpkin")) { }
            
            
            Destroy(col.gameObject);
            Debug.Log("kaban enter", null);
        }
    }

    bool AnimatorIsPlaying(string stateName)
    {
        return anim.GetCurrentAnimatorStateInfo(0).length >
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
