using System;
using System.Collections.Generic;
using BinaryClock.Universal.Framework;

namespace BinaryClock.Universal.Features.Clock
{
    public class ClockViewModel : ObservableObject
    {
        public ClockViewModel()
        {
            InitializeBinaryDigits();
        }

        public void LoadDateTime(DateTime dateTime)
        {
            var timeOfDay = dateTime.TimeOfDay;

            var numbersToLoad = new int[]
            {
                timeOfDay.Hours / 10,
                timeOfDay.Hours % 10,
                timeOfDay.Minutes / 10,
                timeOfDay.Minutes % 10,
                timeOfDay.Seconds / 10,
                timeOfDay.Seconds % 10,
            };

            for (var i = 0; i < 6; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    if (numbersToLoad[i] > 0)
                    {
                        _binaryDigits[i, j].Value = numbersToLoad[i] % 2 == 1;
                        numbersToLoad[i] /= 2;
                    }
                    else
                        _binaryDigits[i, j].Value = false;
                }
            }

        }

        private void InitializeBinaryDigits()
        {
            for (var i = 0; i < _binaryDigits.GetLength(0); i++)
                for (var j = 0; j < _binaryDigits.GetLength(1); j++)
                    _binaryDigits[i, j] = new ObservableBoolean(false);
        }

        private void ResetBinaryDigits()
        {
            for (var i = 0; i < _binaryDigits.GetLength(0); i++)
                for (var j = 0; j < _binaryDigits.GetLength(1); j++)
                    _binaryDigits[i, j].Value = false;
        }

        private ObservableBoolean[,] _binaryDigits = new ObservableBoolean[6, 4];
        public ObservableBoolean[,] BinaryDigits
        {
            get => _binaryDigits;
            private set
            {
                if (RaisePropertyChanged(ref _binaryDigits, ref value))
                {
                    RaisePropertyChanged(nameof(EnumerableBinaryDigits));
                    RaisePropertyChanged(nameof(EnumerableHourBinaryDigits));
                    RaisePropertyChanged(nameof(EnumerableMinuteBinaryDigits));
                    RaisePropertyChanged(nameof(EnumerableSecondBinaryDigits));
                }
            }
        }

        public List<List<ObservableBoolean>> EnumerableHourBinaryDigits
        {
            get
            {
                return new List<List<ObservableBoolean>>
                {
                    new List<ObservableBoolean> { _binaryDigits[0,3], _binaryDigits[0, 2] , _binaryDigits[0, 1] , _binaryDigits[0, 0] },
                    new List<ObservableBoolean> { _binaryDigits[1,3], _binaryDigits[1, 2] , _binaryDigits[1, 1] , _binaryDigits[1, 0] },
                };
            }
        }

        public List<List<ObservableBoolean>> EnumerableMinuteBinaryDigits
        {
            get
            {
                return new List<List<ObservableBoolean>>
                {
                    new List<ObservableBoolean> { _binaryDigits[2,3], _binaryDigits[2, 2] , _binaryDigits[2, 1] , _binaryDigits[2, 0] },
                    new List<ObservableBoolean> { _binaryDigits[3,3], _binaryDigits[3, 2] , _binaryDigits[3, 1] , _binaryDigits[3, 0] },
                };
            }
        }

        public List<List<ObservableBoolean>> EnumerableSecondBinaryDigits
        {
            get
            {
                return new List<List<ObservableBoolean>>
                {
                    new List<ObservableBoolean> { _binaryDigits[4,3], _binaryDigits[4, 2] , _binaryDigits[4, 1] , _binaryDigits[4, 0] },
                    new List<ObservableBoolean> { _binaryDigits[5,3], _binaryDigits[5, 2] , _binaryDigits[5, 1] , _binaryDigits[5, 0] },
                };
            }
        }

        public List<List<ObservableBoolean>> EnumerableBinaryDigits
        {
            get
            {
                return new List<List<ObservableBoolean>>
                {
                    new List<ObservableBoolean> { _binaryDigits[0,3], _binaryDigits[0, 2] , _binaryDigits[0, 1] , _binaryDigits[0, 0] },
                    new List<ObservableBoolean> { _binaryDigits[1,3], _binaryDigits[1, 2] , _binaryDigits[1, 1] , _binaryDigits[1, 0] },
                    new List<ObservableBoolean> { _binaryDigits[2,3], _binaryDigits[2, 2] , _binaryDigits[2, 1] , _binaryDigits[2, 0] },
                    new List<ObservableBoolean> { _binaryDigits[3,3], _binaryDigits[3, 2] , _binaryDigits[3, 1] , _binaryDigits[3, 0] },
                    new List<ObservableBoolean> { _binaryDigits[4,3], _binaryDigits[4, 2] , _binaryDigits[4, 1] , _binaryDigits[4, 0] },
                    new List<ObservableBoolean> { _binaryDigits[5,3], _binaryDigits[5, 2] , _binaryDigits[5, 1] , _binaryDigits[5, 0] },
                };
            }
        }
    }
}
