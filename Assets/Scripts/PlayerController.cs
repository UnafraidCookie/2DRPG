using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float Speed;
    private Animator anim;
    private bool movementStatus;
    private Vector2 lastMove;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();   
	}
	
	// Update is called once per frame
	void Update ()
    {
        movementStatus = false;
	    if(Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime, 0f));
            movementStatus = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        if (Input.GetAxisRaw("Vertical") > 0.1f || Input.GetAxisRaw("Vertical") < -0.1f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime));
            movementStatus = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("MovementStatus", movementStatus);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
	}
}
