using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreHandler : MonoBehaviour {

    public Text ScoreText;
    public string ScorePrefix;
    public int ScoreIncrement;
    int PlayerScore;
    
    void Start () {
        Meteor.MeteorDestroyed += AddScore;
        Meteor.MeteorDestroyed += UpdateScoreText;

        PlayerScore = 0;
        ScoreText.text = ScorePrefix + PlayerScore.ToString();
	}
	
	void Update () {
        Debug.Log(PlayerScore);
	}

    void AddScore()
    {
        PlayerScore += ScoreIncrement;
    }

    void UpdateScoreText()
    {
        ScoreText.text = ScorePrefix + PlayerScore.ToString();
    }
}
