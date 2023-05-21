using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.AI;

public class AIControlTest : MonoBehaviour
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator AIControlTestWithEnumeratorPasses()
    {
        yield return new WaitForSeconds(5);
        GameObject walk = GameObject.CreatePrimitive(PrimitiveType.Plane);
        walk.transform.localScale = new Vector3(10, 1, 10);
        var plane = walk.AddComponent<NavMeshSurface>();
        plane.BuildNavMesh();

        yield return new WaitForSeconds(5);

        var gameObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        gameObject.transform.position = new Vector3(5.0f, 1.000000000f, 5.0f);
        gameObject.AddComponent<NavMeshAgent>();
        var ai = gameObject.AddComponent<AIControl>();

        yield return new WaitForSeconds(1);

        ai.setDestination();

        yield return new WaitForSeconds(5);

        int x = (int)gameObject.transform.position.x;
        int y = (int)gameObject.transform.position.y;
        int z = (int)gameObject.transform.position.z;

        Vector3 currentPosition = new Vector3(x, y, z);

        Assert.AreEqual(new Vector3(0, 1, 0), currentPosition);
    }
}
