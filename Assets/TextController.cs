using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;

	public enum States {cell, mirror, bed_0, lock_0, freedom, restart};
	private States myState;

	public bool hasKey = false;
	public bool hasMirror = false;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {

		print (myState);
		if(myState == States.cell){
			state_cell();
		} else if(myState == States.bed_0){
			state_bed_0();
		} else if(myState == States.mirror){
			state_mirror();
		} else if(myState == States.lock_0 && hasKey == false && hasMirror == false){
			state_lock_0();
		} else if(myState == States.lock_0 && hasKey == true && hasMirror == false){
			state_lock_1();
		} else if(myState == States.lock_0 && hasMirror == true && hasKey == false){
			state_lock_2();
		} else if(myState == States.lock_0 && hasKey == true && hasMirror == true){
			state_lock_3();
		} else if(myState == States.freedom){
			state_freedom();
		} else if(myState == States.restart){
			state_restart();
		}
	}

	void state_cell() {
		text.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"Press B to view the Bed, M to view the Mirror, and L to view the Lock.";
		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.bed_0;
		} else if (Input.GetKeyDown (KeyCode.M)) {
			myState = States.mirror;
		} else if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.lock_0;
		}

	}
	void state_bed_0() {
		text.text = "You look under the bed and find a shiny key that you had stolen from a guard earlier and you grab the key.\n\n" +
					"Press R to return to your cell.";
		hasKey = true;
		print ("hasKey = " + hasKey);
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}

	void state_mirror(){
		text.text = "You see that the mirrior is hanging on a wire like a photo. You take it down and look at yourself.\n\n" +
					"Press R to take the mirror and go back to roaming your cell, ";
		hasMirror = true;
		print ("hasMirror = " + hasMirror);
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}

	void state_lock_0(){
		text.text = "Yeah it's a lock... so what?\n\n" +
					"Press R to return to your cell.";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}
	
	void state_lock_1(){
		text.text = "You may have a key but you can't see the lock.\n\n" +
			"Press R to return to your cell.";
		print ("hasKey = " + hasKey);
		print ("hasMirror = " + hasMirror);
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}

	void state_lock_2(){
		text.text = "You need a key.\n\n" +
					"Press R to return to your cell.";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}
	
	void state_lock_3(){
		text.text = "You hold the mirror outside the cell and put the key in the lock and turn it\n\n" +
					"Press F to run to freedom.";
		if (Input.GetKeyDown (KeyCode.F)) {
			myState = States.freedom;
		}
	}

	void state_freedom(){
		text.text = "YOUR FREE!!!.\n\n" +
					"Press R to start over";
		hasKey = false;
		hasMirror = false;
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.restart;
		}
	}

	void state_restart(){
		text.text = "Are you sure?\n\n" +
					"Yes(ENTER) or No(ESC)";
		if (Input.GetKeyDown (KeyCode.Return)) {
			myState = States.cell;
		} else if (Input.GetKeyDown (KeyCode.Escape)) {
			myState = States.freedom;
		}
	}
}
