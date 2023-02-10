using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectableCoins : MonoBehaviour
{
    public int coins=0;
    public string con="Congrats";
    public AudioSource audio;
    
    [SerializeField]
    public Text coinCollector;

    // Start is called before the first frame update
    void Start()
    {
        audio=GetComponent<AudioSource> ();
        //coinCollector=GameObject.Find("Coins").GetComponent<Text>();
    }
    public void OnTriggerEnter(Collider Col){
        if(Col.gameObject.tag == "Coin"){
            audio.Play();
            if(coins>4){
                SceneManager.LoadScene(con);
            }
            UnityEngine.Debug.Log("Coin is collected");
            UnityEngine.Debug.Log(coins);
            coins = coins +1;
            Col.gameObject.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        // coinCollector.text="Coins: "+coins;
        // coinCollector.GetComponent<Text>().text = "Coins: "+coins.ToString();
    }
}
