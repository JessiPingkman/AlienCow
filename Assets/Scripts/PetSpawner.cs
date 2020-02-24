using UnityEngine;

public class PetSpawner : Spawner
{
    private void Start() {
        Spawn();    
    }

    protected override void Spawn()
    {
        for(int i = 0; i < Count; i++){
            base.Spawn();
        }
    }    
}
