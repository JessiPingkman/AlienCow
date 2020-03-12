using Common;
using Enums;

public class PetSpawner : Spawner
{
    private void Start() {
        for(int i = 0; i<SpawnCount; i++)
        {
            CountManager.Instance.Increment(CounterTag.Pets);
            Spawn(SpawnPosition.position);
        }
    }
}
