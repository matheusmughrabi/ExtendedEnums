namespace ExtendedEnums
{
    public class EnumResult
    {
        public EnumResult()
        {
        }

        public EnumResult(long value, string description)
        {
            Value = value;
            Description = description;
        }

        public long Value { get; set; }
        public string Description { get; set; }
    }
}
