using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropper_script : MonoBehaviour
{
	// References to the different falling blocs (prefabs):
	public GameObject bloc;
	private GameObject currentBlock;  // Reference to last bloc spawned
	private bloc_script currentBlockScript;  // Reference to the script of that bloc

    void createBlock() {
		// Create an instance of the prefab and keep a reference to this instance
		currentBlock = Instantiate(bloc, transform.position, Quaternion.identity) as GameObject;
		if (currentBlock != null) {
			currentBlockScript = currentBlock.GetComponent<bloc_script>();
		}
    }

    // Start is called before the first frame update
	void Awake() {
		createBlock();
	}

    // Update is called once per frame
    void Update() {
		// If the bloc has landed, create a new one
		if (currentBlockScript.hasLanded) {
			createBlock();
		}
    }
}
