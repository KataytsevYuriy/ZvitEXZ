namespace ZvitEXZ.Models.Calculations
{
    public class KorNebezpechny : Dylyanka
    {
        public string Description { get; set; }
        public KorNebezpechny(double kmStart, double kmEnd, string description) : base(kmStart, kmEnd)
        {
            Description = description;
        }
        public override Dylyanka Trim(Dylyanka trimmer, ref Dylyanka ostatok)
        {
            Dylyanka result = null;
            KorNebezpechny korNeb = ostatok as KorNebezpechny;
            if (KmStart < trimmer.KmStart && KmEnd >= trimmer.KmStart)
            {
                result = new KorNebezpechny(ostatok.KmStart, trimmer.KmStart, korNeb.Description);
            }
            if (ostatok.KmStart <= trimmer.KmEnd && ostatok.KmEnd > trimmer.KmEnd &&
                trimmer.KmEnd < KmEnd)
            {
                ostatok = new KorNebezpechny(trimmer.KmEnd, KmEnd, korNeb.Description);
            }
            else
            {
                ostatok = null;
            }
            return result;
        }
    }
}
