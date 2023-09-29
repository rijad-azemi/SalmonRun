using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class PlayerCollision : MonoBehaviour {

    [SerializeField]
    TextMesh scoreText;
    [SerializeField]
    Text finalScoreText;
    [SerializeField]
    Text highScoreText;
    [SerializeField]
    CanvasGroup GameOverUI;
    [SerializeField]
    ParticleSystem coinPS;

    private GetUsername MessageOBJ;
    private AudioSource audiosrc;

    private bool isPlaying;

    float score = 0.0f;

    private void Start()
    {
        score = 0;
        isPlaying = true;

        MessageOBJ = GameObject.FindGameObjectWithTag("message").GetComponent<GetUsername>();
        audiosrc = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (isPlaying)
        {
            score += Time.deltaTime;
            scoreText.text = Mathf.RoundToInt(score).ToString();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            ObstacleHit(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            CoinHit(other.gameObject,10);
            audiosrc.Play();
        }
        if (other.gameObject.tag == "Coin20")
        {
            CoinHit(other.gameObject,20);
            audiosrc.Play();
        }
        if(other.gameObject.tag == "sidetrigger")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
    void CheckScore()
    {
        if (score > PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("score", (int)score + 1 );
            StartCoroutine(SendToServer());
        }
    }
    private void ObstacleHit(GameObject go)
    {
        MessageOBJ.ShowMessage();

        GetComponent<MeshCollider>().enabled = false;

        CheckScore();
        finalScoreText.text = Mathf.RoundToInt(score).ToString();
        isPlaying = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().enabled = false;
        Time.timeScale = 0.3f;
        GameOverUI.alpha = 1;
        GameOverUI.interactable = true;
        GameOverUI.blocksRaycasts = true;

        scoreText.text = "".ToString();
        highScoreText.text = PlayerPrefs.GetInt("score").ToString();
    }

    private void CoinHit(GameObject go,int score2)
    {
        Instantiate(coinPS, go.transform.position, Quaternion.identity);
        score += score2;
        Destroy(go.gameObject);
    }

    IEnumerator SendToServer()
    {
        int skor = ((int)score + 1);
        string req = "http://seminarski.azurewebsites.net/home/SubmitScore?username="+PlayerPrefs.GetString("Username")+"&score=" + skor.ToString();

        //WWWForm form = new WWWForm();

        //form.AddField("Username", PlayerPrefs.GetString("Username"));
        //form.AddField("Score", (int)score + 1);

        //UnityWebRequest uwr = UnityWebRequest.Get(req);
        WWW post = new WWW(req);
        yield return post;
    }
}
