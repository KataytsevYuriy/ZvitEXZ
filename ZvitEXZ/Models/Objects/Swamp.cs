namespace ZvitEXZ.Models.Objects
{
    public class Swamp : Pereshkoda
    {
        public Swamp(object[] data) : base(data)
        {
            Name = Constants.SwampName;
        }
        public override string ToString()
        {
            return Constants.SwampName;
        }
    }
}
