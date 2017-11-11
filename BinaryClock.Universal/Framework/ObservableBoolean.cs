namespace BinaryClock.Universal.Framework
{
    public class ObservableBoolean : ObservableObject
    {
        public ObservableBoolean(bool value)
        {
            Value = value;
        }

        private bool _value = false;
        public bool Value { get => _value; set => RaisePropertyChanged(ref _value, ref value); }
    }
}
