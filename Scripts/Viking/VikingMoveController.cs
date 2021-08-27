using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikingMoveController: IVikingMoveController
{
    public Vector2 CalcRandomVikingDirection()
    {
        return Random.insideUnitCircle.normalized;
    }

    public Vector2 ReverseDirectionXAxis(Vector2 direction)
    {
        return new Vector2(-direction.x, direction.y);
    }

    public Vector2 ReverseDirectionYAxis(Vector2 direction)
    {
        return new Vector2(direction.x, -direction.y);
    }

    public void VikingMove(Transform viking, float speed, Vector2 direction)
    {
        viking.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
