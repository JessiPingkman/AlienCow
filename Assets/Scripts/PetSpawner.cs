public class PetSpawner : Spawner
{
    private void Start() {
        for(int i = 0; i<spawnCount; i++)
        {
            Spawn(spawnCount, spawnPosition.position);
        }
    }
}
