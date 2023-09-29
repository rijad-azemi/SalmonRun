using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Submit : MonoBehaviour {

    [SerializeField]
    CanvasGroup MainMenuUI;
    [SerializeField]
    CanvasGroup SubmitUI;
    [SerializeField]
    Text InputUI;
    [SerializeField]
    Text MessageUI;
    [SerializeField]
    CanvasGroup MainMenuCanvas;
    [SerializeField]
    CanvasGroup SubmitCanvas;
    [SerializeField]
    Text usernameText;

    void Start ()
    {
        //PlayerPrefs.DeleteAll();
		if(!PlayerPrefs.HasKey("PostojiUsername"))
        {
            SubmitUI.alpha = 1.0f;
            SubmitUI.interactable = true;
            SubmitUI.blocksRaycasts = true;
        }
        else
        {
            MainMenuUI.alpha = 1.0f;
            MainMenuUI.interactable = true;
            MainMenuUI.blocksRaycasts = true;
        }
	}

    public void SubmitButton()
    {
        StartCoroutine(CheckUsernameAvailability());
    }


    IEnumerator CheckUsernameAvailability()
    {
        string req = "http://seminarski.azurewebsites.net/home/UsernameExisting?username=" + InputUI.text;

        WWW post = new WWW(req);
        yield return post;

        if (post.text.Contains("UsernamePostoji"))
        {
            MessageUI.text = "Username already exists";
        }
        else
        {
            string regexString = InputUI.text;

            if(regexString.Length > 30)
                regexString = InputUI.text.Substring(0, 29);

            PlayerPrefs.SetString("Username", regexString);
            PlayerPrefs.SetInt("PostojiUsername", 1);

            MainMenuCanvas.alpha = 1.0f;
            MainMenuCanvas.interactable = true;
            MainMenuCanvas.blocksRaycasts = true;

            SubmitCanvas.alpha = 0f;
            SubmitCanvas.interactable = false;
            SubmitCanvas.blocksRaycasts = false;

            usernameText.text = "Welcome, " + PlayerPrefs.GetString("Username");
        }
    }
}
