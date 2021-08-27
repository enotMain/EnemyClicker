using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class VikingBuff : IVikingBuff 
{
    public int BuffScale { get; set; }
    public float TimerBuffScale { get; set; }
    public float TimeToBuff { get; set; }
    public float LowBorderOfSpawnTime { get; set; }
    public float SpawnScale { get; set; }

    public void VikingBuffByScale(GameObject vikingGO, int scale)
    {
        Viking viking = vikingGO.GetComponent<Viking>();
        viking.Hp *= scale;
        viking.Speed *= scale;
    }

    public bool IsTimeToBuff() 
    {
        if (TimerBuffScale >= TimeToBuff)
        {
            TimerBuffScale = 0;
            return true;
        }
        else return false;
    }

    public void BuffController(bool isTimeToBuff, ref float timeToSpawn)
    {
        if (isTimeToBuff)
        {
            BuffScale++;
            Debug.Log($"Time to Spawn: {timeToSpawn} Spawn Scale: {SpawnScale}");
            if (timeToSpawn > LowBorderOfSpawnTime) timeToSpawn -= SpawnScale;
        } 
    }
}