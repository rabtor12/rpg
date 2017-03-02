using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {

	public void ReactToHit()
    {
        WanderingAL  behavior= GetComponent<WanderingAL>();
        if(behavior!= null)
        {
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());
    }
	void Start () {}
	void Update () {}
    private IEnumerator Die()
    {
        this.transform.Rotate(-75,0,0);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
