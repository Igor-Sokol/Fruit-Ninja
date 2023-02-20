using UnityEngine;

namespace DependencyInjection.Contracts
{
    public abstract class ServicePrefabInstaller : MonoBehaviour, IServicePrefabInstaller
    {
        public abstract void InstallService();
    }
}