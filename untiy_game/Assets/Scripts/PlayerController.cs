using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour {
    void Start()
    {
        ps.Stop();
    }
    
    Vector2 targetPosition;
    public float moveSpeed;
    [SerializeField] ParticleSystem ps;
    Vector2 mousePos;
    
    // Update is called once per frame
    void Update () 
    {
    
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PlayEffect();
        }
    
        MovePlayer(moveSpeed);
    }
    void PlayEffect()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ps.transform.position = new Vector2(mousePos.x, mousePos.y);
        ps.Stop();
        ps.Play();
    }
    public void MovePlayer(float moveSpeed)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }
}
