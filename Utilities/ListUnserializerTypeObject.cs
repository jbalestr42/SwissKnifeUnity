using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SKU {
    public class ListUnserializerTypeObject<T> where T : UnityEngine.Object {

        #region Variables

        private Dictionary<Type, T> _dictionary;

        public Dictionary<Type, T> Dic { get { return _dictionary; } }

        #endregion

        #region Consructor

        public ListUnserializerTypeObject() {
            _dictionary = new Dictionary<Type, T>();
        }

        #endregion

        public void Initialize(List<T> list, bool cleanListAfterInit)
        {
            for(int i = 0; i < list.Count; ++i)
            {
                if (list[i] == null)
                {
                    Log.Error("Element at index [" + i + "] is null");
                    continue;
                }

                if (Dic.ContainsKey(list[i].GetType())) {
                    Log.Error("An object of type [" + list[i].GetType().ToString() + "] is already present.");
                } else
                {
                    _dictionary.Add(list[i].GetType(), list[i]);
                }
            }

            if (cleanListAfterInit)
            {
                list.Clear();
                list = null;
            }
        }
    }
}