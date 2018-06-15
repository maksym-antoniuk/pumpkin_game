using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatController : MonoBehaviour {

    

    private GameObject portal;
    public Text coins; 

	// Use this for initialization
	void Start () {
        coins = GameObject.Find("Coins").GetComponent<Text>();
        coins.text = "Coins : " + PlayerPrefs.GetInt("Coins").ToString();
        portal = GameObject.Find("portal_0");
        //kaban = GameObject.Find("boss");
        
        portal.SetActive(false);
        
    }

    //col.CompareTag("Coin") || col.CompareTag("GapCoin") || 
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin") || col.CompareTag("GapCoin") || col.CompareTag("BossCoin"))
        {
            if (col.CompareTag("Coin"))
            {
                BossController.kek = false;
                BossController.isFacingRight = false;

            }
            if (col.CompareTag("BossCoin"))
            {
                BossController.isFacingRight = true;
                
            }
            if (col.CompareTag("GapCoin"))
            {
                Destroy(GameObject.Find("platform-block-back-09 (276)"));
                GameObject.Find("rock_hanging").GetComponent<BoxCollider2D>().isTrigger = true;
            }
            
            PlayerPrefs.SetInt("Coins", 1 + PlayerPrefs.GetInt("Coins"));
            coins.text = "Coins : " + PlayerPrefs.GetInt("Coins").ToString();
            Destroy(col.gameObject);
            Debug.Log("sad", null);
        } else if(col.CompareTag("Nure"))
        {
            Destroy(col.gameObject);
            portal.SetActive(true);
            Debug.Log("sads", null);
        } else if (col.CompareTag("Portal"))
        {
            portal.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    
}
