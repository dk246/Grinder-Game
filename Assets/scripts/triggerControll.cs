using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerControll : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField]private bool isTop;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "medium" || collision.tag == "large")
        {
            collision.gameObject.GetComponent<lifeBox>().BreakBox();
        }
    }
    /*
    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        yield return new WaitForSeconds(0f);
        if (collision.gameObject.tag == "small" && isTop)
        {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
        yield return new WaitForSeconds(0.5f);
        collision.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        collision.gameObject.GetComponent<PolygonCollider2D>().enabled = false;

    }

   */
}
