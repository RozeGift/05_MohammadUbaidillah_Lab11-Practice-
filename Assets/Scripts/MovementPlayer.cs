using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    float speed = 10;
    int hitpoint = 0;

    public GameObject Enemy;
    bool iscontact = false;
    Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            playerAnim.SetBool("IsStrafe", true);
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.SetBool("IsStrafe", false);
        }
      
        if (Input.GetKeyDown(KeyCode.Space))
            {
            playerAnim.SetTrigger("IsAttacking");
            if(iscontact == true)
            {
                hitpoint++;
                if (hitpoint == 5)
                {
                    print("You have destroyed an enemy!");
                    Destroy(Enemy);
                }
            }

        }
    
       

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Opponent"))
        {
            playerAnim.SetTrigger("Death");
        }
    }
  
    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.CompareTag("Opponent"))
        {
            iscontact = true;
        }
    }

    private void OnTriggerExit(Collider other)

    {
        if (other.gameObject.CompareTag("Opponent"))
        {
            iscontact = false;
        }
    }
}
