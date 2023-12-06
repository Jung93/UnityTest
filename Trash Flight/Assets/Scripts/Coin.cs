using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private float minY = -7f;
    
    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }

    void Jump(){
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        float randomJumpForce = Random.Range(3f, 6f);

        Vector2 jumpVelocity = Vector2.up * randomJumpForce;

        jumpVelocity.x = Random.Range(-1.5f, 1.5f);

        if(jumpVelocity.x <= 0.3f && jumpVelocity.x >= -0.3f){
            if(jumpVelocity.x >=0){
                jumpVelocity.x = 1f;
            } else if(jumpVelocity.x < 0){
                jumpVelocity.x = -1f;
            }
        }

        rigidbody.AddForce(jumpVelocity, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        float toX = Mathf.Clamp(transform.position.x, -2.55f, 2.35f);

        transform.position = new Vector3(toX, transform.position.y,transform.position.z);

        if(transform.position.y  <= minY){
               Destroy(gameObject);
           }


    }
}
