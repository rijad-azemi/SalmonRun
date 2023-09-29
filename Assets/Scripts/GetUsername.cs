using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetUsername : MonoBehaviour {

    [SerializeField]
    Text usernameText;

    private string[] porukeIgracu = { "Nice Swiming", "You're a real fishy fish", "You must be faster than a shark", "Nice moves", "" +
            "I am Groot", "You can do better" };

    private void Start()
    {
        if(PlayerPrefs.HasKey("Username") && gameObject.tag != "ignore")
            usernameText.text = "Welcome, " + PlayerPrefs.GetString("Username");
    }

    public void ShowMessage()
    {
        usernameText.text = porukeIgracu[Random.Range(0, porukeIgracu.Length)] + " " + PlayerPrefs.GetString("Username");
    }
}
