using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1 : MonoBehaviour {
    public float Baddie1Position;
    public float BaddieRotateSpeed;
    public Transform Baddie2Position;
    public float BaddieMoveSpeed;
    public GameObject BadGuy1;
    public GameObject Badguy2;
    public GameObject Soldier1;
    public GameObject Soldier2;
    public GameObject Dialogue;
	// Use this for initialization
	void Start () {
        StartCoroutine(moveBaddies());
	}
    bool moveOne = true;
	// Update is called once per frame
	void Update () {
       
	}
    IEnumerator moveBaddies() {
        while (BadGuy1.transform.position.x < Baddie1Position)
        {
            BadGuy1.transform.Translate(Vector3.right * BaddieMoveSpeed);
            Badguy2.transform.Translate(Vector3.left * BaddieMoveSpeed);
            yield return 0;
        }
         
    }

    
}
