using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject tankManager;
    private TankService tankService;

    public GameObject _camera;
    private CameraControl cameraControl;

    private GameObject tank;

    internal List<Transform> cameraTargets = new List<Transform>();

    private void Awake()
    {
        cameraControl = _camera.GetComponent<CameraControl>();
        tankService = tankManager.GetComponent<TankService>();
    }

    // Start is called before the first frame update
    void Start()
    {
        tank = tankService.getTankControllerRef();
        Debug.Log(tank);
        cameraTargets.Add(tank.transform);
        cameraControl.m_Targets = cameraTargets;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
