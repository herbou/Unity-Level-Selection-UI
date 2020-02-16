using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class GameMap : MonoBehaviour
{
	[Serializable] struct Level
	{
		public string Title;
		public string Description;
		public bool isLocked;
	}

	[SerializeField] Level[] levelsData;

	[SerializeField] Transform points;
	Transform[] levels;
	Transform cam;
	int currentIndex = 0;
	[SerializeField] float speed = .5f;
	[SerializeField] GameObject levelPrefab;
	GameObject go;

	void Start ()
	{
		cam = Camera.main.transform.parent;
		levels = new Transform[points.childCount];
		for (int i = 0; i < levels.Length; i++) {
			levels [i] = points.GetChild (i);
			go = Instantiate (levelPrefab, null);
			go.transform.position = levels [i].position;
			//change level title
			go.transform.GetChild (0).GetComponent <TMP_Text> ().text = levelsData [i].Title;
			//change level description
			go.transform.GetChild (1).GetComponent <TMP_Text> ().text = levelsData [i].Description;
			//change level visibility (access)
			go.transform.GetChild (3).gameObject.SetActive (levelsData [i].isLocked); //true: if level is Unlocked

			//pass index
			go.transform.GetChild (2).GetComponent <MapButton> ().levelIndex = i; 

		}
	}

	void LateUpdate ()
	{
		cam.position = Vector2.Lerp (cam.position, levels [currentIndex].position, speed);
	}

	public void ClickRight ()
	{
		Move (1); //1:right    -1:Left
	}

	public void ClickLeft ()
	{
		Move (-1); //1:right    -1:Left
	}

	void Move (int dir)
	{
		currentIndex += dir;

		currentIndex = (currentIndex < 0) ? levels.Length - 1 : currentIndex;
		currentIndex = (currentIndex >= levels.Length) ? 0 : currentIndex;
	}
}
