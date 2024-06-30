namespace ZvitEXZ.Models.AcadModels
{
    internal class DrawBlock : DrawingStep
    {
        public string BlockName { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double XScale { get; set; }
        public DrawBlock(string blockName, double x, double y, double xScale = 1) : base(AcadConstants.DrawingBlockName)
        {
            BlockName = blockName;
            X = x;
            Y = y;
            XScale = xScale;
        }
        public override int CellsCount()
        {
            return 5;
        }
    }
}
