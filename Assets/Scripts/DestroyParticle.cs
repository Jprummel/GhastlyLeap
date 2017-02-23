using UnityEngine;
using System.Collections;

public class DestroyParticle : MonoBehaviour {

	void Start () {
        Destroy(this.gameObject, 0.4f);
	}
}
