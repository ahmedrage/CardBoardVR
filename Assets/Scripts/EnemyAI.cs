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
	public Question[] questions = new Question[10];
	public string[] test;
	public int score;
	public int scoreForCorrect;
	public int penaltyForIncorrect;
	int currentQuestionNumber;
	string currentQuestionText;


	public Text questionText;
	public Text scoreText;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		scoreText.text = score.ToString ();
		currentQuestionText = questions [currentQuestionNumber].theQuestion;
		questionText.text = currentQuestionText;
		if (Input.GetButtonDown("Fire1")) {
			questionTrue();
			nextQuestion ();
		}
		if (Input.GetButtonDown("Fire2")) {
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
		if (currentQuestionNumber < questions.Length) {
			currentQuestionNumber++;
		}
	}
}