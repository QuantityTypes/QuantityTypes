namespace Forte
{
    public partial struct ShortLength
    {
        public static implicit operator Length(ShortLength l)
        {
            return l.value * Length.Meter;
        }
    }

}