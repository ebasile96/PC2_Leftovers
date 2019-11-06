using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    public PlayerBaseState currentState;

    public float speed;
    public float speedRotation;
    internal Vector3 position;
    internal float targetForward;
    internal Quaternion rotation;
    public float lenghtDash;
    public float distDash;

   

    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;
    }

    public struct InputData
    {
        public float rotate;
        public float forward;
        public bool dash;
        public bool attackMelee;
    }

     InputData GetInput()
    {
        InputData data;

        // input
        data.forward = Input.GetAxis("Vertical");
        data.rotate = Input.GetAxis("Horizontal");
        data.dash = Input.GetKeyDown(KeyCode.LeftShift);
        data.attackMelee = Input.GetKeyDown(KeyCode.Space);

        return data;
    }

    public void ChangeState(PlayerBaseState newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }
    // Update is called once per frame
    void Update()

    {
        var inputData = GetInput();

        currentState.Tick(inputData);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashForward();
            /*if (Input.GetAxis("Vertical") > 0)
            {
                DashForward();
            }

            if (Input.GetAxis("Vertical") < 0)
            {
                DashBack();
            }

            if (Input.GetAxis("Horizontal") > 0)
            {
                DashRight();
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                DashLeft();
            }

            if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                DashForward();
            }*/
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Debug.Log("prende input");
            AttackMelee();
        }


    }

    Vector3 moveDirection;
    public void Move()
    {
        //this.transform.position = this.transform.position + this.transform.forward * speed * Time.deltaTime;
        //this.transform.position = this.transform.position + new Vector3(0.0f, 0.0f, speed * Time.deltaTime);
        //this.transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, speed * Input.GetAxis("Vertical") * Time.deltaTime);
        CharacterController moveController = GetComponent<CharacterController>();
        moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        moveController.Move(moveDirection * Time.deltaTime);
    }

    public void Rotate(float rotate)
    {
        //this.transform.rotation = Quaternion.Euler(Vector3.up * rotate * speedRotation * Time.deltaTime) * rotation;
        this.transform.Rotate(0, Input.GetAxis("Horizontal") * speedRotation, 0);
    }

    public void UpdatePositionAndRotation()
    {
        this.transform.SetPositionAndRotation(this.transform.position , this.transform.rotation);
    }

    public void DashForward()
    {
        //this.transform.DOMove(transform.forward, speedDash);
        this.transform.position += this.transform.forward * lenghtDash;
    }
    /*public void DashBack()
    {
        this.transform.DOMoveZ(this.transform.position.z - distDash, speedDash);
    }
    public void DashRight()
    {
        this.transform.DOMoveX(this.transform.position.x + distDash, speedDash);
    }
    public void DashLeft()
    {
        this.transform.DOMoveX(this.transform.position.x - distDash, speedDash);
    }*/

    public int rangeAttack;
    public RaycastHit hit;

    public void AttackMelee()
    {
        Ray rayForward = new Ray(transform.position, transform.forward);
       

        if (Physics.Raycast(rayForward, out hit, rangeAttack) && hit.collider.tag == "Enemy")
        {
            Debug.DrawRay(transform.position + new Vector3(0, 10f), transform.forward * hit.distance, Color.red);
            EnemyHealth eHealth = hit.collider.GetComponent<EnemyHealth>();
            eHealth.TakeDamage(1);
            //testEnemy.transform.DOShakePosition(2f, strength);
            Debug.Log("prende raycast");
        }
        
    }

}
