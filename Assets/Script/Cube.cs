using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cube : MonoBehaviour {

    public int indexRank = 0;
    public int indexCol = 0;
    public int currNum = 2;
    public Text text;
    private Vector3 currPos;

    // Use this for initialization
    void Start ()
    {
        currPos = gameObject.transform.localPosition;
        text.text = currNum.ToString();
    }
        	
	// Update is called once per frame
	void Update () {
	
	}

    public void moveUp(int left, int up)
    {
        currPos.x += left * R.weight;
        currPos.y += up * R.height;
        gameObject.transform.localPosition = currPos;

        indexRank += left;
        indexCol += up;
    }

    public void setText(int num)
    {
        currNum = num;
        text.text = currNum.ToString();

    }

    public void init()
    {
        gameObject.transform.position = R.initPos;
        indexRank = 0;
        indexCol = 0;
    }
}
