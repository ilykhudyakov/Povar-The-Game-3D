﻿using System;
using System.Collections;

namespace povar3d {
    public sealed class ListFixedExecuteObject : IEnumerator, IEnumerable
    {
        private IFixedExecute[] _interactiveObjects;
        private int _index = -1;

        public void AddExecuteObject(IFixedExecute execute)
        {
            if (_interactiveObjects == null)
            {
                _interactiveObjects = new[] { execute };
                return;
            }
            Array.Resize(ref _interactiveObjects, Length + 1);
            _interactiveObjects[Length - 1] = execute;
        }

        public IFixedExecute this[int index]
        {
            get => _interactiveObjects[index];
            private set => _interactiveObjects[index] = value;
        }

        public int Length => _interactiveObjects.Length;

        public bool MoveNext()
        {
            if (_index == _interactiveObjects.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;

        public object Current => _interactiveObjects[_index];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
