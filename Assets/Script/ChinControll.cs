using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChinControll : MonoBehaviour
{
    private string inteOw = "y"; 
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.y < 3.5)
        {
            inteOw = "n";
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inteOw == "y")
        {
            GetComponent<Transform>().position = OWControll.OWxPos;
        
        }

        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            inteOw = "n";
          //  OWControll.spawnedYet = "n";
        
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            OWControll.spawnPos = transform.position;
            OWControll.newChinp = "y";
            OWControll.whichChinp = int.Parse(gameObject.tag);
            Debug.Log(OWControll.whichChinp);
            Destroy(gameObject);
        }
    }
}
