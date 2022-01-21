using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class dropperController: MonoBehaviour
{
	private Object[] blocksPrefabs; // References to falling blocs (prefabs)
	private List<GameObject> blockList;  // References to falling blocks (GameObjects)
	private GameObject currentBlock;  // Reference to instance of last block spawned
	private fallingBlocks currentBlockPropreties;  // Acces propreties of currentBlock

	public bool hasLost = false;

    void createBlock() {
		// Create an instance of the prefab and keep a reference to this instance
		int i = Random.Range(0, blockList.Count);
		currentBlock = Instantiate(blockList[i], transform.position, Quaternion.identity);
		currentBlockPropreties = currentBlock.GetComponent<fallingBlocks>();
    }

    // Start is called before the first frame update
	void Start() {
		blockList = new List<GameObject>();
		string blocksPath = "Prefabs/Blocks";
		blocksPrefabs = Resources.LoadAll(blocksPath);
		blockList = blocksPrefabs.Cast<GameObject>().ToList();
		createBlock();
	}

    // Update is called once per frame
    void Update() {
		// If the block lands, create a new one
		if (currentBlockPropreties.hasLanded) {
			// If the is higher than the dropper, you lost the game.
			// TODO: Finish game if both players lost.
			if (currentBlockPropreties.transform.position.y >= transform.position.y) {
				hasLost = true;
			}

			if (!hasLost) {
				createBlock();
			}
		}
    }
}
