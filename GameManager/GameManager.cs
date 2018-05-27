using System;
using System.Collections.Generic;
using UnityEngine;

namespace SKU
{
    /// <summary>
    /// An abstract class is used instead of an inteface to inheris from ScriptableObject
    /// </summary>
    public abstract class AManagers : ScriptableObject {

        public abstract void Init();
    }

    public class GameManager : Singleton<GameManager>
    {

        public List<AManagers> ManagersList;
        private ListUnserializerTypeObject<AManagers> _managers;

        #region Properties
        
        public AManagers Get(Type key)
        {
            AManagers value = null;

            if (!_managers.Dic.TryGetValue(key, out value))
            {
                Log.Error("The game manager does not contains a manager of type [" + key.ToString() + "]", gameObject);
            }

            return value;
        }

        #endregion

        #region Unity_Methods

        private void Awake()
        {
            _managers = new ListUnserializerTypeObject<AManagers>();

            for (int i = 0; i < ManagersList.Count; ++i)
            {
                ManagersList[i].Init();
                _managers.Dic.Add(ManagersList[i].GetType(), ManagersList[i]);
            }

            _managers.Initialize(ManagersList, true);
        }

        #endregion
    }
}