using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private float startY, startZ;

    // Start is called before the first frame update
    void Start()
    {
      if (!player) {
        return;
      }
      startY = transform.position.y;
      startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
      if (!player) {
        return;
      }
      transform.position = new Vector3(player.position.x, startY, startZ);
    }
}
