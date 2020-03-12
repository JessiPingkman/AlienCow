public class PetSpawner : Spawner
{
    private void Start() {
        for(int i = 0; i<SpawnCount; i++)
        {
            Spawn(SpawnPosition.position);
        }
    }
}
