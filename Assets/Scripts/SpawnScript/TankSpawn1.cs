using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawn1 : MonoBehaviour
{
    public GameObject Tank1;
    public Transform spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Tank = Instantiate(Tank1, new Vector2(spawnPos.position.x, spawnPos.position.y), spawnPos.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
