namespace ZvitEXZ.Models.Objects
{
    public class Swamp : Pereshkoda
    {
        public Swamp(object[] data) : base(data)
        {
            Name = ProjectConstants.SwampName;
        }
        public override string ToString()
        {
            return ProjectConstants.SwampName;
        }
    }
}
