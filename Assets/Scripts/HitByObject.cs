using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitByObject : MonoBehaviour
{
    MeshRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Player"){
            renderer.material.color = Color.red;
        }
    }
}
