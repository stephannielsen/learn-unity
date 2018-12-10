using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	private int _max;
	private int _min;
	private int _guess;
	
	// Use this for initialization
	void Start()
	{
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			_min = _guess;
			NextGuess();
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			_max = _guess;
			NextGuess();
		}
		else if (Input.GetKeyDown(KeyCode.Return))
		{
			print ("I won!");
			StartGame();
		}
	}
	
	void StartGame () {
		
		_min = 1;
		_max = 1001;
		_guess = 500;
		
		print("Welcome to Number Wizard");
		print("Pick a number in your head, but don't tell me!");
		
		print("The highest number you can pick is " + (_max - 1));
		print("The lowest number you can pick is " + _min);
		
		print("Is the number higher or lower than " + _guess + "?");
		print("Up = higher, down = lower, return = equal");
	}
	
	void NextGuess ()
	{
		_guess = (_max + _min) / 2;
		print("Is the number higher or lower than " + _guess + "?");
		print("Up = higher, down = lower, return = equal");
	}
}
