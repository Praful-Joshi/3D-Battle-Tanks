using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    //other scripts declaration
    private TankModel tankModel;
    private TankView tankView;

    public TankController(TankModel tankModel, TankView tankView)
    {
        this.tankModel = tankModel;
        this.tankView = GameObject.Instantiate<TankView>(tankView);
    }
}
