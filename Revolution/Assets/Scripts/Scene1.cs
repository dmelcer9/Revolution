using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(LineRenderer))]
public class Scene1 : MonoBehaviour {
    public float Baddie1Position;
    public float BaddieRotateSpeed;
    public float BaddieMoveSpeed;
    public GameObject drSteinein;
    public GameObject BadGuy1;
    public GameObject Badguy2;
    public GameObject Soldier1;
    public GameObject Soldier2;
    public GameObject Soldier1Weapon;
    public Material lazerMaterial;
    public Material badLazer;
    public Text dialogue;
    public GameObject SoldierFiringPoint;
    public GameObject BaddieFiringPoint;
    public GameObject leg;
    // Use this for initialization
    SpriteRenderer sp;
	void Start () {
        sp = GetComponent<SpriteRenderer>();
        StartCoroutine(moveBaddies());
	}
    bool moveOne = true;
	// Update is called once per frame
	void Update () {
       
	}
    LineRenderer line;
    private void shootLaser(GameObject startPoint, GameObject endPoint,Material m) {
        line  = GetComponent<LineRenderer>();
        line.numPositions =2;
        line.material = m;
        line.startWidth = .1f;
        line.endWidth = .25f;
        line.enabled = true;
        line.sortingLayerName = "Weapons";
        line.SetPosition(0,startPoint.transform.position);
        line.SetPosition(1, endPoint.transform.position);
    }
    IEnumerator moveBaddies() {
         string nextLine = "Soldier 1 - Man it's cold \n Press Space";
         for (int i = 0; i <= nextLine.Length; i++) {
              dialogue.text = nextLine.Substring(0,i);
              yield return new WaitForSeconds(.04f);
          }
          while (!Input.GetKeyUp(KeyCode.Space)) yield return 0;
          yield return new WaitForSeconds(.1f);
          nextLine = "Soldier 2 - At least we're really important. We need to protect Dr. Steinein \n Press Space";
          for (int i = 0; i <= nextLine.Length; i++)
          {
              dialogue.text = nextLine.Substring(0, i);
              yield return new WaitForSeconds(.04f);
          }
          while (!Input.GetKeyUp(KeyCode.Space)) yield return 0;
          nextLine = "Soldier 1 - Shhhh. Do you hear that? \n Press Space";
          for (int i = 0; i <= nextLine.Length; i++)
          {
              dialogue.text = nextLine.Substring(0, i);
              yield return new WaitForSeconds(.04f);
          }
          yield return new WaitForSeconds(.01f);
          while (!Input.GetKeyUp(KeyCode.Space)) yield return 0;

          //start moving badguys
          while (BadGuy1.transform.position.x < Baddie1Position)
          {
              BadGuy1.transform.Translate(Vector3.right * BaddieMoveSpeed);
              Badguy2.transform.Translate(Vector3.left * BaddieMoveSpeed);
              yield return 0;
          }

          //start next round of dialogue
          nextLine = "Baddie 1 - Give Us Dr. Steinein \n Press Space";
          for (int i = 0; i <= nextLine.Length; i++)
          {
              dialogue.text = nextLine.Substring(0, i);
              yield return new WaitForSeconds(.04f);
          }
          yield return new WaitForSeconds(.01f);
          while (!Input.GetKeyUp(KeyCode.Space)) yield return 0;
          nextLine = "Soldier 2 - Maybe we should do what they tell us \n Press Space";
          for (int i = 0; i <= nextLine.Length; i++)
          {
              dialogue.text = nextLine.Substring(0, i);
              yield return new WaitForSeconds(.04f);
          }
          yield return new WaitForSeconds(.01f);
          while (!Input.GetKeyUp(KeyCode.Space)) yield return 0;
          nextLine = "Baddie 2 Yesss! You should \n Press Space";
          for (int i = 0; i <= nextLine.Length; i++)
          {
              dialogue.text = nextLine.Substring(0, i);
              yield return new WaitForSeconds(.04f);
          }
          yield return new WaitForSeconds(.01f);
          while (!Input.GetKeyUp(KeyCode.Space)) yield return 0;
          nextLine = "Soldier 1 - Never!! \n Press Space";
          for (int i = 0; i <= nextLine.Length; i++)
          {
              dialogue.text = nextLine.Substring(0, i);
              yield return new WaitForSeconds(.04f);
          }
        yield return new WaitForSeconds(.01f);
        while (!Input.GetKeyUp(KeyCode.Space)) yield return 0;
          dialogue.text = "";
  
        //start fight scene
          
        while (BadGuy1.transform.position.x < Baddie1Position)
        {
            BadGuy1.transform.Translate(Vector3.right * BaddieMoveSpeed);
            Badguy2.transform.Translate(Vector3.left * BaddieMoveSpeed);
            yield return 0;
        }
        //good shot
        shootLaser(SoldierFiringPoint,BadGuy1,lazerMaterial);
        yield return new WaitForSeconds(.7f);
        line.enabled = false;
        for (int i=0;i<45;i++) {
            BadGuy1.transform.Rotate(Vector3.forward*2);
            yield return 0;
        }
        //bad shot
        shootLaser(BaddieFiringPoint, Soldier1, badLazer);
        yield return new WaitForSeconds(.7f);
        line.enabled = false;
        for (int i = 0; i < 45; i++)
        {
            Soldier1.transform.Rotate(Vector3.forward * 2);
            yield return 0;
        }
        //Second Bad shot 
        shootLaser(BaddieFiringPoint, leg, badLazer);
        yield return new WaitForSeconds(.7f);
        line.enabled = false;
        //second good shot
        Soldier1Weapon.transform.Rotate(Vector3.up * 180);
        shootLaser(SoldierFiringPoint, Badguy2, lazerMaterial);
        yield return new WaitForSeconds(.7f);
        line.enabled = false;
        for (int i = 0; i < 45; i++)
        {
            Badguy2.transform.Rotate(Vector3.back * 2);
            yield return 0;
        }
        for (int i = 0; i < 45; i++)
        {
            Soldier2.transform.Rotate(Vector3.back * 2);
            yield return 0;
        }
        //bring Steinein to front
        sp.sortingLayerName = "People";
        nextLine = "Dr Steinein - By Golly I got it. This will certainly end the war. \n";
        for (int i = 0; i <= nextLine.Length; i++)
        {
            dialogue.text = nextLine.Substring(0, i);
            yield return new WaitForSeconds(.04f);
        }
        yield return new WaitForSeconds(.01f);
        while (!Input.GetKeyUp(KeyCode.Space)) yield return 0;
        nextLine = "Soldier 1 - MY LEG!! \n";
        for (int i = 0; i <= nextLine.Length; i++)
        {
            dialogue.text = nextLine.Substring(0, i);
            yield return new WaitForSeconds(.04f);
        }
        yield return new WaitForSeconds(.01f);
    }

    
}
