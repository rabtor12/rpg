using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    private int healf;
	
	void Start () {
        healf = 5;
	}
	
	
	void Update () {
		
	}
    public void Hurt (int damage)
    {
        healf -= damage;
        Debug.Log("Healf:" + healf);
    }
}
