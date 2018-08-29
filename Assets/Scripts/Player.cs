using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	//Component References--------------------------------------------------------------------------------------------------//
	private CharacterController m_Controller;
	private Camera m_Camera;


	//Movement Values-------------------------------------------------------------------------------------------------------//
	private Vector3 m_MoveDirection;
	private Vector3 m_GravityDirection;

	[Header("Move Values")]
	[SerializeField] private float m_CurrentSpeed = 0;
	[SerializeField] private float m_WalkSpeed = 1;
	[SerializeField] private float m_RunSpeed = 1;
	[SerializeField] private float m_TargetFOV;
	[SerializeField] private float m_WalkingFOV = 60;
	[SerializeField] private float m_RunningFOV = 70;
	[Space]
	[SerializeField] private float m_JumpSpeed = 1;
	[SerializeField] private float m_JumpModifier = 1;
	[SerializeField] private float m_Gravity = 1;
	[SerializeField] private float m_AirDrag = 1;
	[Space]
	[SerializeField] private float m_StandingHeight = 2;
	[SerializeField] private float m_CrouchingHeight = 1;
	[SerializeField] private float m_CameraHeightOffset = 0;

	//Look Values-----------------------------------------------------------------------------------------------------------//
	[Header("Look Values")]
	[SerializeField] private float m_LookSensX = 10;
	[SerializeField] private float m_LookSensY = 10;
	[Space]
	[SerializeField] private int m_MinRotX = -360;
	[SerializeField] private int m_MaxRotX = 360;
	[SerializeField] private int m_MinRotY = -60;
	[SerializeField] private int m_MaxRotY = 60;

	private float m_RotX = 0;
	private float m_RotY = 0;

	private Quaternion m_StartRot;


	//----------------------------------------------------------------------------------------------------------------------//
	private void Awake()
	{
		//Misc
		Cursor.lockState = CursorLockMode.Locked;

		//Assign references
		m_Controller = GetComponent<CharacterController>();
		m_Camera = transform.Find("Camera").GetComponent<Camera>();
	}

	private void Start()
	{
		//Set Initial Values
		m_MoveDirection = Vector3.zero;
		m_CurrentSpeed = m_WalkSpeed;
		m_TargetFOV = m_WalkingFOV;
		m_StartRot = transform.rotation;
	}

	private void Update()
	{
		Inputs();
		Move();
		Look();
	}

	private void Inputs()
	{
		if(m_Controller.isGrounded)
		{
			//Controls whether player is running or not
			if(Input.GetKeyDown(KeyCode.LeftShift))
			{
				m_CurrentSpeed = m_RunSpeed;
				m_TargetFOV = m_RunningFOV;
			}
			if(Input.GetKeyUp(KeyCode.LeftShift))
			{
				m_CurrentSpeed = m_WalkSpeed;
				m_TargetFOV = m_WalkingFOV;
			}

			//Controls player jumping
			if(Input.GetButtonDown("Jump"))
			{
				m_GravityDirection.y = m_JumpSpeed;
				m_JumpModifier = 2.0f;
			}

			//Controls player crouching
			if(Input.GetButtonDown("Crouch"))
			{
				m_Controller.height = m_CrouchingHeight;
				m_Camera.transform.localPosition = new Vector3(0, m_CrouchingHeight - m_CameraHeightOffset, 0);
			}
			if(Input.GetButtonUp("Crouch"))
			{
				m_Controller.height = m_StandingHeight;
				m_Camera.transform.localPosition = new Vector3(0, m_StandingHeight - m_CameraHeightOffset, 0);
			}
		}

		//Sets the direction of player
		m_MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		m_MoveDirection = transform.TransformDirection(m_MoveDirection);
		m_MoveDirection *= m_CurrentSpeed;
	}

	private void Move()//Controls player movement
	{
		//Adds gravity to controller
		m_GravityDirection.y -= m_Gravity * m_JumpModifier * Time.deltaTime;
		if(m_GravityDirection.y < -m_Gravity)
		{
			m_GravityDirection.y = -m_Gravity;
		}

		//Adds movement drag if the player is not on the ground
		if(!m_Controller.isGrounded)
		{
			m_MoveDirection *= m_AirDrag;
		}

		//Moves controller
		m_Controller.Move((m_MoveDirection + m_GravityDirection) * Time.deltaTime);

		//Maintains JumpModifier
		if(m_Controller.isGrounded && m_JumpModifier > 1)
		{
			m_JumpModifier = 1.0f;
		}

		//Controls FOV
		if(m_Camera.fieldOfView != m_TargetFOV)
		{
			m_Camera.fieldOfView = Mathf.Lerp(m_Camera.fieldOfView, m_TargetFOV, Time.deltaTime * 10);
		}

	}

	private void Look()//Controls player looking
	{
		m_RotX += Input.GetAxis("Mouse X") * m_LookSensX;
		m_RotY += Input.GetAxis("Mouse Y") * m_LookSensY;

		m_RotX = ClampAngle(m_RotX, m_MinRotX, m_MaxRotX);
		m_RotY = ClampAngle(m_RotY, m_MinRotY, m_MaxRotY);

		Quaternion xQuat = Quaternion.AngleAxis(m_RotX, Vector3.up);
		Quaternion yQuat = Quaternion.AngleAxis(m_RotY, -Vector3.right);

		transform.localRotation = m_StartRot * xQuat;
		m_Camera.transform.localRotation = m_StartRot * yQuat;
	}

	public static float ClampAngle (float angle, float min, float max)
 	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp (angle, min, max);
	}
}
