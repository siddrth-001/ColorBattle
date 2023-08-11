using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGenerated : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Invoke("Diminish",7); 
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale +=Time.deltaTime*.5f;
    }

    void Diminish()
    {
        Destroy(gameObject,1.0f);
    }
}
