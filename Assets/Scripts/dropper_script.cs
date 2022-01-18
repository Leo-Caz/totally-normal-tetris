using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropper_script : MonoBehaviour
{
	// References to the different falling blocs (prefabs):
	public GameObject bloc;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bloc, transform.position, Quaternion.identity);
    }

    /* // Update is called once per frame */
    /* void Update() */
    /* { */
        
    /* } */
}
