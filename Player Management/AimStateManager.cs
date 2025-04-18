using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AimStateManager : MonoBehaviour
{
    public Cinemachine.AxisState xAxis, yAxis;
    [SerializeField] Transform camFollowPos;
    private Animator animator;
    [SerializeField] private CinemachineVirtualCamera AimCamera;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    private float aimSmoothSpeed = 5f;
    public GameObject crosshair;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
        {
            crosshair.SetActive(true);
            animator.SetBool("Aiming", true);
            AimCamera.gameObject.SetActive(true);

     

            Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
            {
                debugTransform.position = Vector3.Lerp(debugTransform.position, raycastHit.point, aimSmoothSpeed * Time.deltaTime);
            }

        }


        else
        {

            animator.SetBool("Aiming", false);
            AimCamera.gameObject.SetActive(false);

        }

    }

        

    
    private void LateUpdate()

    {
        camFollowPos.localEulerAngles = new Vector3(yAxis.Value, camFollowPos.localEulerAngles.y, camFollowPos.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis.Value, transform.eulerAngles.z);

    }
}
