namespace MVC5Course.Models.DataTypes
{
    using System.ComponentModel.DataAnnotations;

    public class 身分證字號Attribute : DataTypeAttribute
    {
        public 身分證字號Attribute() : base(DataType.Text)
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            string str = (string)value;

            if (str.Contains("Will"))
            {
                return true;
            }

            return false;
        }
    }
}