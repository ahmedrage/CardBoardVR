using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

[System.Serializable]
public class Question {
	//[SerializeField]
	public string theQuestion;
	public string response1;
	public string response2;
	public bool isYes;

}

public class EnemyAI : MonoBehaviour {
	public Question[] questions;
	public int score;
	public int scoreForCorrect;
	public int penaltyForIncorrect;
	public int currentQuestionNumber;
	string currentQuestionText;

	public Text questionText;
	public Text scoreText;

	public Text response1Text;
	public Text response2Text;

	public bool response1Hover;
	public bool response2Hover;
	public pointer VR;
	// Use this for initialization
	void Start () {
		VR = GameObject.FindGameObjectWithTag ("Head").GetComponent<pointer> ();
	}

	// Update is called once per frame
	void Update () {


		print (questions [0].theQuestion);
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

		if (response1Hover == true) {
			response1Text.text = questions [currentQuestionNumber].response1;
		} else {
			response1Text.text = "";
		}

		if (response2Hover == true) {
			response2Text.text = questions [currentQuestionNumber].response2;
		} else {
			response2Text.text = "";
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