using GirlInTheForest.Models;
using System;
using System.Collections.Generic;

namespace GirlInTheForest
{
    class Forest
    {
        List<Girl> _lostGirls;

        List<Girl> _findGirls;

        public delegate void _findGirl(string message);

        public static event _findGirl NearLine;

        public static event _findGirl Searched;

        public delegate void _find(string message);

        public static event _find SearchedGirls;

        int size;

        public Forest(int _size)
        {
            size = _size;

            _lostGirls = new List<Girl>();

            _findGirls = new List<Girl>();
        }

        public void AddToLostInForest(Girl girl)
        {
            _lostGirls.Add(girl);
        }

        public bool IsSavedByOutOfMap(Girl girl)
        {
            if (_lostGirls.Contains(girl) && !_findGirls.Contains(girl))
            {
                if (NearLine != null)
                {
                    if (girl.XPos == size - 1 ||
                        girl.XPos == 0 ||
                        girl.YPos == size - 1 ||
                        girl.YPos == 0)
                    {
                        NearLine($"Девочка {girl.Abbreviation} вышла из леса");

                        _findGirls.Add(girl);

                        return false;
                    }
                }
            }
            return true;
        }

        public void IsSavedByParents(Parent parent)
        {
            if (Searched != null)
            {
                for (int i = 0; i < _lostGirls.Count; i++)
                {
                    if (!_findGirls.Contains(_lostGirls[i]))
                    {
                        if (Math.Abs(_lostGirls[i].XPos - parent.XPos) < 4 && Math.Abs(_lostGirls[i].YPos - parent.YPos) < 4)
                        {
                            Searched($"Девочку {_lostGirls[i].Abbreviation} нашли родители." + parent.Abbreviation);

                            _findGirls.Add(_lostGirls[i]);
                        }
                    }
                }
            }
        }

        public bool FindGirls()
        {
            if (SearchedGirls != null)
            {
                if (_findGirls.Count == _lostGirls.Count)
                {
                    SearchedGirls("Девочка спасена");

                    return false;
                }
            }
            return true;
        }
    }
}
