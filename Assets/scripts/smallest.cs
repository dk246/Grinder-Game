using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class smallest : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isFall = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        //BottomCollector
        if (isFall)
        {
            gameObject.transform.position += new Vector3(1 * Time.deltaTime, 0, 0);
        }
    }
    
  
 

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BottomCollector")
        {
            isFall = true;
        }
    }
}
