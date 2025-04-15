using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    void onTriggerEnter2D(Collider collision)
    {
        if(collision.CompareTag("player"))
        {
            SceneManager.LoadScene("gameOver");
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
