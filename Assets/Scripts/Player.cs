using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody body;

    Vector3 playerInput;

    float runSpeed = 500f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Run();
    }
    void OnMove(InputValue value){
        float xFloat = value.Get<Vector2>().x * Time.deltaTime * runSpeed;
        float yFloat = value.Get<Vector2>().y * Time.deltaTime * runSpeed;
        if(transform.localEulerAngles.y > 80 && transform.localEulerAngles.y < 100){
            float temp = xFloat;
            xFloat = yFloat;
            yFloat = -temp;
        }
        else if(transform.localEulerAngles.y > 170 && transform.localEulerAngles.y < 190){
            xFloat = -xFloat;
            yFloat = -yFloat;
        }
        else if (transform.localEulerAngles.y > 260 && transform.localEulerAngles.y < 290)
        {
            float temp = xFloat;
            xFloat = -yFloat;
            yFloat = temp;
        }
        playerInput = new Vector3(xFloat, 0f, yFloat);
    }
    void Run(){
        playerInput = new Vector3(playerInput.x, body.velocity.y, playerInput.z);
        body.velocity = playerInput;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Rotator"){
            transform.Rotate(0,90,0);
            Debug.Log(transform.localEulerAngles.y);
            other.gameObject.tag = "Untagged";
        }
    }
}
