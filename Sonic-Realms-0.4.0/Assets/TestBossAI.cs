using UnityEngine;

public class TestBossAI : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0.001f * (transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x), 0, 0);
    }
}
