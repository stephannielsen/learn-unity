using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	
	private enum States
	{
		Cell,
		Mirror,
		Sheets0,
		Sheets1,
		Lock0,
		Lock1,
		CellMirror,
		Corridor0,
		Corridor1,
		Corridor2,
		Corridor3,
		Stairs0,
		Stairs1,
		Stairs2,
		Floor,
		ClosetDoor,
		InCloset,
		Courtyard
	}
	
	private States _currentState;
	private int _stairsTries = 0;
	
	public Text text;
	
	// Use this for initialization
	void Start ()
	{
		_currentState = States.Cell;
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (_currentState)
		{
			case States.Cell:
				Cell();
				break;
			case States.CellMirror:
				CellMirror();
				break;
			case States.Sheets0:
				Sheets0();
				break;
			case States.Sheets1:
				Sheets1();
				break;
			case States.Mirror:
				Mirror();
				break;
			case States.Lock0:
				Lock0();
				break;
			case States.Lock1:
				Lock1 ();
				break;
			case States.Corridor0:
				Corridor0();
				break;
			case States.Corridor1:
				Corridor1();
				break;
			case States.Corridor2:
				Corridor2();
				break;
			case States.Corridor3:
				Corridor3();
				break;
			case States.Stairs0:
				Stairs0();
				break;
			case States.Stairs1:
				Stairs1();
				break;
			case States.Stairs2:
				Stairs2();
				break;
			case States.Floor:
				Floor();
				break;
			case States.ClosetDoor:
				ClosetDoor();
				break;
			case States.InCloset:
				InCloset();
				break;
			case States.Courtyard:
				Courtyard();
				break;
		}
	}
	
	void Cell()
	{
		text.text = "Hey, what the fuck? Where am I? Prison?...Ugh what a headache!" +
			"Is this what our prisons look like? Dirty sheets, and just a mirror besides the locked door?" +
			"How can I get out of here?\n\n" +
			"Press S to view Sheets, press M to view Mirror, " +
			"and press L to view Lock";
		if (Input.GetKeyDown(KeyCode.S))
		{
			_currentState = States.Sheets0;
		}
		else if (Input.GetKeyDown (KeyCode.M))
		{
			_currentState = States.Mirror;
		}
		else if (Input.GetKeyDown(KeyCode.L))
		{
			_currentState = States.Lock0;
		}
	}
	
	void CellMirror()
	{
		text.text = "Ah now I don't have to look at myself anymore. But what to do next?\n\n"
			+ "Press S to view Sheets or press L to view Lock.";
		if (Input.GetKeyDown(KeyCode.S))
			_currentState = States.Sheets1;
		else if (Input.GetKeyDown(KeyCode.L))
			_currentState = States.Lock1;
	}
	
	void Sheets0()
	{
		text.text = "Whhaaaat?! I slept in these?! No way! Guard! Please change them now! " +
			"Oh, prison...as if somebody cares...\n\n" +
				"Press C to check out your cell again.";
		if (Input.GetKeyDown(KeyCode.C))
			_currentState = States.Cell;
	}
	
	void Sheets1()
	{
		text.text = "Even with a mirror in my hand the sheets are still dirty.\n\n" +
				"Press C to check out your cell again.";
		if (Input.GetKeyDown(KeyCode.C))
			_currentState = States.CellMirror;
	}
	
	void Lock0()
	{
		text.text = "A keypad lock. How am I supposed to know the combination? It's not like I can " +
			"see dirty fingerprints on the used buttons...\n\n" +
				"Press C to check out your cell again.";
		if (Input.GetKeyDown(KeyCode.C))
			_currentState = States.Cell;
	}
	
	void Lock1()
	{
		text.text = "Uh. I can take a look at the keypad if I put the mirror through the bars. No way! The last " +
			"guard must have eaten something nasty! Let's press the same buttons he did...*click*...ah, that's " +
			" a sound I like to hear.\n\n" +
			"Press O to open the door or C to check out your cell again.";
		if (Input.GetKeyDown(KeyCode.C))
			_currentState = States.CellMirror;
		else if (Input.GetKeyDown(KeyCode.O))
			_currentState = States.Corridor0;
	}
	
	void Mirror()
	{
		text.text = "Ugh, that's me? I look like shit!. Better take that thing of the wall!\n\n" +
			"Press T to take the mirror or C to return to you cell.";
		if (Input.GetKeyDown(KeyCode.T))
			_currentState = States.CellMirror;
		else if (Input.GetKeyDown(KeyCode.C))
			_currentState = States.Cell;
	}
	
	void Corridor0()
	{
		text.text = "Ok, I am out of the cell and in the corridor - what now?\n\n" +
			"Press S to walk up the Stairs, F to look at the Floor, " +
			"or D to look at the closet Door on the right.";
		if (Input.GetKeyDown(KeyCode.S))
			_currentState = States.Stairs0;
		if (Input.GetKeyDown(KeyCode.F))
			_currentState = States.Floor;
		if (Input.GetKeyDown(KeyCode.D))
			_currentState = States.ClosetDoor;
	}
	
	void Stairs0()
	{
		text.text = "Uh shit, guards out on the courtyard! Damn, that was close but " +
			"they did not see me.\n\n" +
			"Press H to Hurry back down the stairs.";
		if (Input.GetKeyDown(KeyCode.H))
			_currentState = States.Corridor0;
	}
	
	void ClosetDoor()
	{
		text.text = "Locked.\n\n" +
			"Press B to step Back.";
		if (Input.GetKeyDown (KeyCode.B))
			_currentState = States.Corridor0;
	}
	
	void Floor()
	{
		text.text = "Ugh - dirty. Hell, what did I expect? " +
			"Pommes, burger, hairclip, poop?! Somebody has a weird habit here.\n\n" +
			"Pick up the Hairclip with H, or eat one of those delicious Pommes with P.";
		if (Input.GetKeyDown(KeyCode.H))
			_currentState = States.Corridor1;
		if (Input.GetKeyDown(KeyCode.P))
			_currentState = States.Corridor0;
	}
	
	void Corridor1()
	{
		text.text = "Well...my bald head definetly cannot make use of this hairclip...\n\n" +
			"Walk up the Stairs with S or take a shot at Picking that closet door with P.";
		if (Input.GetKeyDown(KeyCode.S))
			_currentState = States.Stairs1;
		if (Input.GetKeyDown(KeyCode.P))
			_currentState = States.InCloset;
	}
	
	void Stairs1()
	{
		text.text = "Ahh, the guards are still standing there! That hairclip ain't gonna keep them from " +
			"seeing my prison clothes...\n\n" +
			"Press H to Hurry back down the stairs.";
		if (Input.GetKeyDown(KeyCode.H))
			_currentState = States.Corridor1;
	}
	
	void InCloset()
	{
		text.text = "Seems to be the cleaners room. Some dirty mobs, dirty water, dirty cleaner clothes..." +
			"Uh my size! Fancy!\n\n" +
			"Press R to Return to corridor or press D to Dress up as a cleaner.";
		if (Input.GetKeyDown(KeyCode.R))
			_currentState = States.Corridor2;
		if (Input.GetKeyDown(KeyCode.D))
			_currentState = States.Corridor3;
	}
	
	void Corridor2()
	{
		text.text = "Maybe the guards left the courtyard...\n\n" +
			"Walk up the Stairs again with S or step back in the Closet.";
		if (Input.GetKeyDown(KeyCode.S))
			_currentState = States.Stairs2;
		if (Input.GetKeyDown(KeyCode.C))
			_currentState = States.InCloset;
	}
	
	void Stairs2()
	{
		if (_stairsTries <= 1)
		{
			text.text = "Nope - still there. I shouldn't push my luck probably...\n\n" +
				"Press H to Hurry back down the stairs.";
			if (Input.GetKeyDown(KeyCode.H))
			{
				_stairsTries += 1;
				_currentState = States.Corridor2;
			}
		}
		else
		{
			text.text = "One to many, I knew it - *klonk*...the guard saw you and knocked you out...\n\n" +
				"Press P to play again.";
			if (Input.GetKeyDown(KeyCode.P))
			{
				_stairsTries = 0;
				_currentState = States.Cell;
			}
		}
	}
	
	void Corridor3()
	{
		text.text = "When did that cleaner shower the last time? How can he clean something " +
			"if he cannot keep himself clean?\n\n" +
			"Walk up the Stairs with S or Undress quickly in the closet with U.";
		if (Input.GetKeyDown(KeyCode.S))
			_currentState = States.Courtyard;
		if (Input.GetKeyDown(KeyCode.U))
			_currentState = States.InCloset;
	}
	
	void Courtyard()
	{
		text.text = "Ok, walking straight, don't look them directly in the eyes..." +
			"you are almost out...just a few more steps...I can smell freedom..." +
			"ugh - no that's just the cleaners smell.\n\n" +
			"Press P to Play again.";
		if (Input.GetKeyDown(KeyCode.C))
		{
			_stairsTries = 0;
			_currentState = States.Cell;
		}
	}
}
