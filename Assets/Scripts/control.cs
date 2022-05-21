using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public float moveSpeed = 5f;
    float xDirection; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per framez
    void Update()
    {
        // Input dương => GameObject->Right //  Input âm => GameObject->Left
        xDirection = Input.GetAxisRaw("Horizontal");

        float moveStep = moveSpeed * xDirection * Time.deltaTime;

        // Nếu vị trí left/right đạt giới hạn => không di chuyển
        if((transform.position.x <= -3.64 && xDirection < 0 ) || (transform.position.x >= 3.64 && xDirection > 0 ))
            return;

        transform.position = transform.position + new Vector3(moveStep,0,0);

        // -3.6 left 
        // 3.6 right 
    }
}
