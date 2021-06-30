using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] private float maxSwerveAmount;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float borderLimit;

    private Rigidbody playerRb;


    float swerveAmount;
    float lastFrameMousePosX;
    public GameObject gameObjectt;
    public GameObject stackGameObject;

    public GameObject follow;
    public GameObject stack;
    public GameObject followw;
    public GameObject stackk;

    [HideInInspector]
    public List<GameObject> _list = new List<GameObject>();



    [HideInInspector]
    public List<GameObject> _listRight = new List<GameObject>();

    [HideInInspector]
    public int n = 1;

    [HideInInspector]
    public int m = 1;

    private void Start()
    {
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();

        LeftLegStart();
        RightLegStart();

        RightLeg.OnRightShoesCollected += RightLegFunct;
        LeftLeg.OnLeftShoesCollected += LeftLegFunct;
        Movement.OnMovement += Move;
        
    }

    

    private void LeftLegStart()
    {
        stack.gameObject.transform.position += -stack.transform.up * gameObjectt.transform.localScale.y;
        GameObject _gameObject = Instantiate(stackGameObject, stack.gameObject.transform.position, Quaternion.identity);
        _list.Add(_gameObject);
        stack.gameObject.transform.parent = _list[0].gameObject.transform;
        stack.transform.rotation = _list[0].transform.rotation;
        _list[0].transform.parent = follow.transform;
    }
    public void LeftLegFunct()
    {
        stack.gameObject.transform.position += -stack.transform.up * gameObjectt.transform.localScale.y;
        GameObject _gameObject = Instantiate(gameObjectt, stack.gameObject.transform.position, Quaternion.identity);
        _list.Add(_gameObject);

        if (_list.Count >= 2)
        {
            _list[n].transform.parent = _list[n - 1].transform;

            _list[n].transform.rotation = _list[n - 1].transform.rotation;

            _list[n].transform.localScale = new Vector3(1, 1, 1);

            n = _list.Count;
            
        }

    }

    private void RightLegStart()
    {
        stackk.gameObject.transform.position += -stackk.transform.up * gameObjectt.transform.localScale.y;
        GameObject _gameObject = Instantiate(stackGameObject, stackk.gameObject.transform.position, Quaternion.identity);
        _listRight.Add(_gameObject);

        stackk.gameObject.transform.parent = _listRight[0].gameObject.transform;

        stackk.transform.rotation = _listRight[0].transform.rotation;

        _listRight[0].transform.parent = followw.transform;

    }

    public void RightLegFunct()
    {
        stackk.gameObject.transform.position += -stackk.transform.up * gameObjectt.transform.localScale.y;
        GameObject _gameObjecttt = Instantiate(gameObjectt, stackk.gameObject.transform.position, Quaternion.identity);
        _listRight.Add(_gameObjecttt);
        

        if (_listRight.Count >= 2)
        {
            
            _listRight[m].transform.parent = _listRight[m - 1].transform;

            _listRight[m].transform.rotation = _listRight[m - 1].transform.rotation;

            _listRight[m].transform.localScale = new Vector3(1, 1, 1);

            m = _listRight.Count;
            
        }
    }

    public void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameMousePosX = Input.mousePosition.x;

        }
        else if (Input.GetMouseButton(0))
        {
            float _inputDifference = Input.mousePosition.x - lastFrameMousePosX;

            swerveAmount = Mathf.Clamp((_inputDifference) * Time.fixedDeltaTime * sensitivity, -maxSwerveAmount, maxSwerveAmount);

            lastFrameMousePosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            swerveAmount = 0;

        }


        /*
        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);

            switch (_touch.phase)
            {
                case TouchPhase.Moved:
                    swerveAmount = Mathf.Clamp(_touch.deltaPosition.x, -maxSwerveAmount, maxSwerveAmount);
                    break;
                case TouchPhase.Canceled:
                case TouchPhase.Ended:
                    swerveAmount = 0;
                    break;
            }
        }
        */
        PlayerMovement();
    }

    public void PlayerMovement()
    {

        Vector3 _horizontalVelocity = transform.right * swerveAmount * sensitivity;
        Vector3 _forwardVelocity = transform.forward * forwardSpeed;
        Vector3 _finalVelocity = _forwardVelocity + _horizontalVelocity;

        playerRb.MovePosition(playerRb.position + _finalVelocity);

    }


}