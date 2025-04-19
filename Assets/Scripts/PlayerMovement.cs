using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController cc;

    [SerializeField] Animator anim;

    private float speed = 5.0f;
    private float rotationSpeed = 720f;
    private float gravity = -9.81f;
    private float yVelocity = 0f;
    private float yVelocityWhenGrounded = -4f;
    private float jumpHeight = 7.0f;    // the height of our jump in units
    private float jumpTime = 0.8f;      // the time of our jump in seconds
    private float initialJumpVelocity;  // upward velocity for jumping (precalculated)

    private float jumpsAvailable = 0;
    private float jumpsMax = 2;

    [SerializeField] private GameObject model;
    private float rotateToFaceMovementSpeed = 5f;

    [SerializeField] private Camera cam;
    private float rotateToFaceAwayFromCameraSpeed = 5f;
    public GameObject player;
    public GameObject dialogueManager1;
    public GameObject dialogueManager2;
    public GameObject dialogueManager3;
    public SuccessPopup successPopup;
    public GameObject StartBanner;
    public GameObject CoinTipBoard;
    public GameObject EnemyTipBoard;
    public GameObject MovingPlatformTipBoard;

    [SerializeField] private Transform spawnPoint1;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private HealthBarManager healthBarManager;

    private void Start()
    {
        float timeToApex = jumpTime / 2.0f;
        gravity = (-2 * jumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameManager == null)
            return;

        if (other.CompareTag("StartBanner"))
        {
            gameManager.HideBanner();
        }
        if (other.CompareTag("coinTipBoard"))
        {
            gameManager.ShowCoinTip();
        }
        if (other.CompareTag("EnemyTipBoard"))
        {
            gameManager.ShowEnemyTip();
        }
        if (other.CompareTag("MovingPlatformTipBoard"))
        {
            gameManager.ShowMovingPlatformTip();
        }
        if (other.CompareTag("Finish"))
        {
            successPopup.Open();
        }
        if (other.CompareTag("lava"))
        {
            Debug.Log("lava touched");
            if (healthBarManager != null)
            {
                healthBarManager.DamagePlayer();
            }
        }
        if (other.CompareTag("levelA"))
        {
            gameManager.SetSpawnPoint(gameManager.spawnPoint1);
        }

        if (other.CompareTag("levelB"))
        {
            gameManager.SetSpawnPoint(gameManager.spawnPoint2);
        }
    }
    void Update()
    {
        if (gameManager == null) return;

        if (healthBarManager != null && healthBarManager.CurrentHealth <= 0)
        {
            RespawnPlayer();
        }

        // determine XZ movement vector
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizInput, 0, vertInput);

        // ensure diagonal movement doesn't exceed horiz/vert movement speed
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        anim.SetFloat("Velocity", movement.magnitude);

        // convert from local to global coordinates
        movement = transform.TransformDirection(movement);

        if (movement.magnitude > 0)
        {
            RotateModelToFaceMovement(movement);
            RotatePlayerToFaceAwayFromCamera();
        }
        movement *= speed;

        // calculate yVelocity and add it to the player's movement vector
        yVelocity += gravity * Time.deltaTime;

        // if we are on the ground and we were falling
        if (cc.isGrounded && yVelocity < 0.0)
        {
            yVelocity = yVelocityWhenGrounded;
            jumpsAvailable = jumpsMax;
            anim.SetBool("isFalling", false);
        }
        if (yVelocity < -40)
        {
            anim.SetBool("isFalling", true);
        }
        if (yVelocity < -41)
        {
            yVelocity = -41;
        }
        // give upward y Velocity if we jumped
        if (Input.GetButtonDown("Jump") && jumpsAvailable > 0)
        {
            yVelocity = initialJumpVelocity;
            jumpsAvailable--;
            anim.SetTrigger("Jump");
        }
        //If grounded
        anim.SetBool("isGrounded", cc.isGrounded);

        movement.y = yVelocity;

        movement *= Time.deltaTime; // make all movement processor independent

        // move the player  (using the character controller)
        cc.Move(movement);

        // rotate the player
        //Vector3 rotation = Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Mouse X");
        //transform.Rotate(rotation);
    }


    private void RotateModelToFaceMovement(Vector3 moveDirection)
    {
        // Determine the rotation needed to face the direction of movement (only XZ movement - ignore Y)
        Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));

        // set the model's rotation
        //model.transform.rotation = newRotation;

        // replace the above line with this one to enable smoothing
        model.transform.rotation = Quaternion.Slerp(model.transform.rotation, newRotation, rotateToFaceMovementSpeed * Time.deltaTime);
    }

    // set the player's Y rotation (yaw) to be aligned with the camera's Y rotation
    private void RotatePlayerToFaceAwayFromCamera()
    {
        // isolate the camera's Y rotation
        Quaternion camRotation = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);

        // set the player's rotation
        //transform.rotation = camRotation;

        // replace the above line with this one to enable smoothing
        transform.rotation = Quaternion.Slerp(transform.rotation, camRotation, rotateToFaceAwayFromCameraSpeed * Time.deltaTime);
    }

    public void RespawnPlayer()
    {
        if (gameManager != null)
        {
            gameManager.RespawnPlayer(player);
            transform.position = spawnPoint1.position;
            yVelocity = 0;
        }
    }
}
