using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class lifeBox : MonoBehaviour
{

    private int life;
    public string type;  //small medium large
    [SerializeField] private GameObject[] normalBoxes;
    [SerializeField] private GameObject[] specialBoxes;

    // Called when a 2D collision happens
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("hit");
        // Check if the other collider is a BoxCollider2D
        if (collision.gameObject.tag == "teeth")
        {
            life++;
            //Debug.Log("Polygon Collider collided with Box Collider!");
            BreakBox();
        }
    }

    public void BreakBox()
    {
        if (type == "large" && life == 8)
        {
            for (int x = 0; x < 4; ++x)
            {
                Instantiate(normalBoxes[0], transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        if (type == "medium" && life == 5)
        {
            for (int x = 0; x < 4; ++x)
            {
                Instantiate(normalBoxes[1], transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }

        if (type == "special_large" && life == 12)
        {
            for (int x = 0; x < 4; ++x)
            {
                Instantiate(specialBoxes[0], transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }


        if (type == "special_medium" && life == 7)
        {
            for (int x = 0; x < 4; ++x)
            {
                Instantiate(specialBoxes[1], transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
