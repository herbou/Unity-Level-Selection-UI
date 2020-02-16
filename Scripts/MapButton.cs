using UnityEngine;

public class MapButton : MonoBehaviour
{
	public int levelIndex;

	void OnMouseDown ()
	{
		//load level 
		Debug.Log (levelIndex);
	}
}
