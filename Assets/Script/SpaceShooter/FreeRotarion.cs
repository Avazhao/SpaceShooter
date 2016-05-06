using UnityEngine;
using System.Collections;

public class FreeRotarion : MonoBehaviour {

    public Transform player;

    private Vector3 offest;


	// Use this for initialization
	void Start () {
        offest = player.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (player)
        {
            transform.position = player.position - offest;
        }
        
	}
}
