namespace ZvitEXZ.Models.Objects
{
    public class Swamp : Pereshkoda
    {
        public Swamp(object[] data) : base(data)
        {
            Name = ProjectConstants.SwampName;
            IsOrientir = true;
        }
        public override string ToString()
        {
            return ProjectConstants.SwampName;
        }
        public override string GetCadType()
        {
            return AcadConstants.ObjSwampNP;
        }
    }
}
