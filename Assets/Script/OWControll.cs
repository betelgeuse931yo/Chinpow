using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OWControll : MonoBehaviour
{
    [SerializeField] private float _minx = -5.5f;
    [SerializeField] private float _maxx = 5.0f;

    public Transform[] chinObj;
    static public string spawnedYet = "n";
    static public Vector2 OWxPos;
    static public Vector2 spawnPos;
    static public string newChinp = "n";
    static public int whichChinp = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnChinp();
        replaceChinp();

        var pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, _minx, _maxx);

        transform.position = pos;

        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 0);
        }

        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2, 0);
        }

        if ((!Input.GetKey("a")) && (!Input.GetKey("d")))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        OWxPos = transform.position;

        if (Input.GetKeyDown("space") && (spawnedYet == "y"))
        {
            spawnedYet = "n";
        
        }

    }

    void spawnChinp()
    {
        if (spawnedYet == "n")
        {
            StartCoroutine(spawnTimer());  
            spawnedYet = "w";
        }
    
    }

    void replaceChinp()
    {
        if (newChinp == "y")
        {
            newChinp = "n";
            Instantiate(chinObj[whichChinp], spawnPos, chinObj[0].rotation);
        }
    
    }

    IEnumerator spawnTimer()
    {
        //Wait for sec, about .75 sec
        //Get rondom object from 0 to 3
        yield return new WaitForSeconds(.75f);
        Instantiate(chinObj[Random.Range(0, 3)], transform.position, chinObj[0].rotation);
        spawnedYet = "y";
    }
}
