using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject enemy;
    private int count = 20;
    public float rate;

    public int GetCount () {
        return count;
    }
}
