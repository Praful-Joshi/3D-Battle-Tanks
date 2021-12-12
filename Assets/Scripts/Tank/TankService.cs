using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    public TankView tankView;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        for(int i = 0; i < 3; i++)
        {
            CreateNewTank();
        }
    }

    private TankController CreateNewTank()
    {
        TankModel tankModel = new TankModel(10, 100f);
        TankController tankController = new TankController(tankModel, this.tankView);
        return tankController;
    }
}
