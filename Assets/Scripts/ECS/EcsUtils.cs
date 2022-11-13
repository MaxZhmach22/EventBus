using Leopotam.EcsLite;
using Leopotam.EcsLite.ExtendedSystems;


namespace EventBus.ECS
{
    public static class EcsUtils
    {
        public static IEcsSystems ClearInput(this IEcsSystems systems)
        {
            return systems
                .DelHere<UpDirectionRequest>()
                .DelHere<DownDirectionRequest>()
                .DelHere<LeftDirectionRequest>()
                .DelHere<RightDirectionRequest>();
        }
    }
}