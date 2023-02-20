using UnityEngine;

namespace DependencyInjection.Contracts
{
    public abstract class ServiceInstaller : MonoBehaviour, IServiceInstaller
    {
        public abstract void InstallService();
    }
}