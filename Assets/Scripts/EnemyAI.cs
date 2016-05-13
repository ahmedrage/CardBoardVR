using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

[System.Serializable]
public class Question {
	//[SerializeField]
	public string theQuestion;
	public bool isYes;

}

public class EnemyAI : MonoBehaviour {
	public Question[] questions;
	public string[] test;
	public int score;
	public int scoreForCorrect;
	public int penaltyForIncorrect;
	public int currentQuestionNumber;
	string currentQuestionText;

	public Text questionText;
	public Text scoreText;

	public pointer VR;
	// Use this for initialization
	void Start () {
		VR = GameObject.FindGameObjectWithTag ("Head").GetComponent<pointer> ();
	}

	// Update is called once per frame
	void Update () {
		scoreText.text = score.ToString ();
		currentQuestionText = questions [currentQuestionNumber].theQuestion;
		questionText.text = currentQuestionText;
		if (VR.questionAnswered == true && VR.yes == true) {
			questionTrue();
			nextQuestion ();
		}
		if (VR.questionAnswered == true && VR.no == true) {
			questionFalse();
			nextQuestion ();
		}



	}

	void questionTrue () {
		if (questions [currentQuestionNumber].isYes == true) {
			score += scoreForCorrect;
		} else {
			score -= penaltyForIncorrect;
		}
	}

	void questionFalse () {
		if (questions [currentQuestionNumber].isYes == false) {
			score += scoreForCorrect;
		} else {
			score -= penaltyForIncorrect;
		}
	}

	void nextQuestion() {
		if (currentQuestionNumber < questions.Length -1) {
			currentQuestionNumber++;
		} else {
			print ("No more questions!!!! Everyody panic");
		}
	}
}