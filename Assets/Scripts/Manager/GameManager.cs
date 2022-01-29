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
        tankService = tankManager.GetComponent<TankService>();
        cameraControl = _camera.GetComponent<CameraControl>(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        tank = tankService.getTankControllerRef();
        cameraTargets.Add(tank.transform);
        cameraControl.m_Targets = cameraTargets;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
