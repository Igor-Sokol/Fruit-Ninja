using System.Collections.Generic;
using System.Linq;
using GameSystems.SceneChangeSystem;
using Models.DependencyInjection;
using Models.PopUpSystem.Contracts;
using UnityEngine;

namespace Models.PopUpSystem
{
    public class PopUpManager : MonoBehaviour
    {
        private SceneChanger _sceneChanger;
        private BasePopUp _activePanel;
        private List<BasePopUp> _gamePanelInstances;
        private PopUpContainer _popUpContainer;

        [SerializeField] private BasePopUp[] panelPrefabs;

        private void Start()
        {
            _sceneChanger = ProjectContext.Instance.GetService<SceneChanger>();
            _sceneChanger.OnSceneLoaded += OnSceneChanged;
            OnSceneChanged();
        }

        private void OnSceneChanged()
        {
            _gamePanelInstances = new List<BasePopUp>();
            _popUpContainer = ProjectContext.Instance.GetService<PopUpContainer>();
            _activePanel = null;
        }

        private void OnEnable()
        {
            if (_sceneChanger)
            {
                _sceneChanger.OnSceneLoaded += OnSceneChanged;
            }
        }
        
        private void OnDisable()
        {
            if (_sceneChanger)
            {
                _sceneChanger.OnSceneLoaded -= OnSceneChanged;
            }
        }

        public void Show(string id)
        {
            if (_activePanel)
            {
                _activePanel.Hide();
            }

            var instance = _gamePanelInstances.FirstOrDefault(p => p && p.PanelUniqueId == id);

            if (!instance)
            {
                var prefab = panelPrefabs.FirstOrDefault(p => p.PanelUniqueId == id);

                if (prefab)
                {
                    instance = Instantiate(prefab, _popUpContainer.transform);
                    instance.Init(this);
                    _gamePanelInstances.Add(instance);
                    instance.Show();
                }
            }
            else
            {
                instance.Show();
            }

            _activePanel = instance;
        }

        public void Hide(BasePopUp basePopUp)
        {
            if (basePopUp == _activePanel)
            {
                basePopUp.Hide();
                _activePanel = null;
            }
        }
    }
}